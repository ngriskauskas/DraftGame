using System.Linq;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api.Handlers
{
    public class StandingsHubUpdateHandler : IHandle<StandingsChangedEvent>
    {
        private readonly IHubContext<StandingsHub, IStandingsHub> _standingsHub;

        public StandingsHubUpdateHandler(IHubContext<StandingsHub, IStandingsHub> standingsHub)
        {
            _standingsHub = standingsHub;
        }
        public void Handle(StandingsChangedEvent domainEvent)
        {
            var teams = domainEvent.Standings.Teams
            .Select(t => new TeamViewModel
            {
                Name = t.Name,
                Wins = t.Record.Wins,
                Losses = t.Record.Losses,
                Ties = t.Record.Ties
            }).ToArray();
            _standingsHub.Clients.All.UpdateStandings(teams);
        }
    }
}