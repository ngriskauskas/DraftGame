using System.Collections.Generic;
using System.Linq;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;

namespace Draft.Core.Handlers
{
    public class GameWeekHandler : IHandle<GameWeekStartedEvent>
    {
        private readonly IRepository _repository;
        private readonly ITimerService _timer;
        private readonly IDomainEventDispatcher _dispatcher;
        private readonly List<Game> _games;
        private readonly List<Team> _teams;
        private readonly Season _season;


        public GameWeekHandler(IRepository repository, ITimerService timer, IDomainEventDispatcher dispatcher)
        {
            _repository = repository;
            _timer = timer;
            _dispatcher = dispatcher;
            _season = _repository.Get(new CurrentSeasonWithStandingsTeams());
            _games = _repository.List(new GamesOnDate(_season.CurDate));
            _teams = _repository.List(new TeamWithRecord());
        }
        public void Handle(GameWeekStartedEvent domainEvent)
        {
            _timer.StartTimer(30, new GameWeekTimerEndedEvent());
            PlayGames();
            UpdateRecords();
            UpdateStandings();
        }

        private void PlayGames()
        {
            foreach (Game game in _games)
                game.Play();

            _repository.UpdateRange<Game>(_games);
        }
        private void UpdateRecords()
        {
            foreach (Game game in _games)
            {
                if (game.IsTie)
                {
                    game.HomeTeam.Record.Ties++;
                    game.AwayTeam.Record.Ties++;
                }
                else if (game.Winner == game.HomeTeam)
                {
                    game.HomeTeam.Record.Wins++;
                    game.AwayTeam.Record.Losses++;
                }
                else if (game.Winner == game.AwayTeam)
                {
                    game.HomeTeam.Record.Losses++;
                    game.AwayTeam.Record.Wins++;
                }
            }
            _repository.UpdateRange(_teams);
            _dispatcher.Dispatch(new TeamRecordsChangedEvent());
        }
        private void UpdateStandings()
        {
            var standings = _season.Standings;
            var arcTeams = new List<ArcTeam>();
            foreach (var game in _games)
                arcTeams.AddRange(game.GameTeams.Select(gt => new ArcTeam(gt)));

            _repository.AddRange(arcTeams);

            standings.Update(arcTeams);
            _repository.Update(standings);
            _dispatcher.Dispatch(new StandingsChangedEvent(standings));
        }
    }
}