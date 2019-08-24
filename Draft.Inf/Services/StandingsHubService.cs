using System.Linq;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Inf.Hub;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Inf.Services
{
    public class StandingsHubService : IHandle<StandingsChangedEvent>
    {
        private readonly IHubContext<StandingsHub, IStandingsHub> _standingsHub;

        public StandingsHubService(IHubContext<StandingsHub, IStandingsHub> standingsHub)
        {
            _standingsHub = standingsHub;
        }
        public void Handle(StandingsChangedEvent domainEvent)
        {
            var names = domainEvent.Standings.Teams
            .Select(t => new TeamViewModel
            {
                Name = t.Name,
                Wins = t.Record.Wins,
                Losses = t.Record.Losses,
                Ties = t.Record.Ties
            }).ToArray();
            _standingsHub.Clients.All.UpdateStandings(names);
        }
    }

    public class TeamViewModel
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
    }
}