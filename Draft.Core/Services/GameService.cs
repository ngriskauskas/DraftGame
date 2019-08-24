using System;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;

namespace Draft.Core.Services
{
    public class GameService : IHandle<GameStartedEvent>
    {
        private enum HomeAdv
        {
            OffAdv,
            DefAdv
        }
        private readonly IRepository _repository;
        private readonly IResourceProvider _resources;
        private Game _game;

        public GameService(IRepository repository, IResourceProvider resources)
        {
            _repository = repository;
            _resources = resources;
        }
        public void Handle(GameStartedEvent domainEvent)
        {
            _game = _repository.Get<Game>(new FullGame(domainEvent.Game.Id));
            CalcScores();
            UpdateRecords();
            UpdateStandings();
        }

        private void CalcScores()
        {
            var homeAdv = (HomeAdv)Enum.GetValues(typeof(HomeAdv)).GetValue(new Random().Next(1));

            int homeRoll = Roll2() + (homeAdv == HomeAdv.OffAdv ? 1 : 0);
            int awayRoll = Roll2() - (homeAdv == HomeAdv.DefAdv ? 1 : 0);

            homeRoll = Clamp(homeRoll, 2, 12);
            awayRoll = Clamp(awayRoll, 2, 12);

            int homeRatDif = _game.HomeTeam.OffRating - _game.AwayTeam.DefRating;
            int awayRatDif = _game.AwayTeam.OffRating - _game.HomeTeam.DefRating;

            homeRatDif = Clamp(homeRatDif, -50, 60);
            awayRatDif = Clamp(awayRatDif, -50, 60);

            int homeScore = _resources.GetGameScores()[60 - homeRatDif][homeRoll - 2];
            int awayScore = _resources.GetGameScores()[60 - awayRatDif][awayRoll - 2];

            _game.Complete(homeScore, awayScore);
        }

        private void UpdateRecords()
        {
            if (_game.IsTie)
            {
                _game.HomeTeam.Record.Ties++;
                _game.AwayTeam.Record.Ties++;
            }
            else if (_game.Winner == _game.HomeTeam)
            {
                _game.HomeTeam.Record.Wins++;
                _game.AwayTeam.Record.Losses++;
            }
            else if (_game.Winner == _game.AwayTeam)
            {
                _game.HomeTeam.Record.Losses++;
                _game.AwayTeam.Record.Wins++;
            }
            _repository.Update(_game.HomeTeam);
            _repository.Update(_game.AwayTeam);
        }

        private void UpdateStandings()
        {
            var standings = _repository.Get<Season>(new CurrentSeasonWithStandingsTeams()).Standings;
            foreach (var gameTeam in _game.GameTeams)
            {
                var arcTeam = new ArcTeam(gameTeam);
                standings.Update(arcTeam);
                _repository.Add(arcTeam);
            }
            _repository.Update(standings);
        }

        private int Roll2()
        {
            var rng = new Random();
            return rng.Next(1, 6) + rng.Next(1, 6);
        }
        private int Clamp(int val, int min, int max)
        {
            return (val < min) ? min : (val > max) ? max : val;
        }

    }
}