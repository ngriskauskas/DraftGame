using AutoMapper;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Web.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api
{
    public class TeamClaimUpdateHandler : IHandle<TeamClaimedEvent>, IHandle<TeamUnClaimedEvent>
    {
        private readonly IHubContext<TeamClaimHub, ITeamClaimHub> _teamClaimHub;
        private readonly IRepository _repository;

        public TeamClaimUpdateHandler(IHubContext<TeamClaimHub, ITeamClaimHub> teamClaimHub,
                                    IRepository repository)
        {
            _teamClaimHub = teamClaimHub;
            _repository = repository;
        }
        public void Handle(TeamClaimedEvent domainEvent)
        {
            _teamClaimHub.Clients.All.TeamClaimed(domainEvent.TeamId);
        }

        public void Handle(TeamUnClaimedEvent domainEvent)
        {
            _teamClaimHub.Clients.All.TeamUnClaimed(domainEvent.TeamId);
        }
    }
}