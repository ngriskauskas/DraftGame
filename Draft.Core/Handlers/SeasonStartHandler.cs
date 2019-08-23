using System.Collections.Generic;
using System.Linq;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;

namespace Draft.Core.Handlers
{
    public class SeasonStartHandler : IHandle<SeasonStartedEvent>
    {
        private readonly IResourceProvider _resourceProvider;
        private readonly IRepository _repository;

        public SeasonStartHandler(IResourceProvider resourceProvider, IRepository repository)
        {
            _resourceProvider = resourceProvider;
            _repository = repository;
        }
        public void Handle(SeasonStartedEvent domainEvent)
        {
            InitGames(domainEvent.Season);
            ResetRecords();
        }

        private void InitGames(Season newSeason)
        {
            var oldSeason = _repository.GetById<Season>(newSeason.Id - 1);
            var teams = oldSeason.Standings.EastStandings
                .Union(oldSeason.Standings.WestStandings)
                .ToArray();
            var gameSchedule = _resourceProvider.GetGameSchedule();
            var gameDates = _resourceProvider.GetGameDates();

            var games = new List<Game>();
            for (int i = 0; i < gameSchedule.Length; i++)
                for (int j = 0; j < gameSchedule[0].Length; j += 2)
                    games.Add
                    (
                        new Game
                        (
                            gameDates[i],
                            teams[gameSchedule[i][j] - 1].Team,
                            teams[gameSchedule[i][j + 1] - 1].Team
                        )
                    );
            _repository.AddRange(games);
        }
        private void ResetRecords()
        {
            var teams = _repository.List(new TeamWithRecord());
            teams.ForEach(t => t.ResetRecord());
            _repository.UpdateRange(teams);
        }
    }
}