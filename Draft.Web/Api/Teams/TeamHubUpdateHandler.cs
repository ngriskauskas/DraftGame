using AutoMapper;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;
using Draft.Web.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api
{
    public class TeamHubUpdateHandler : IHandle<TeamChangedEvent>
    {
        private readonly IRepository _repository;
        private readonly IHubContext<TeamHub, ITeamHub> _teamHub;
        private readonly IMapper _mapper;

        public TeamHubUpdateHandler(IRepository repository,
                                    IHubContext<TeamHub, ITeamHub> teamHub,
                                    IMapper mapper)
        {
            _repository = repository;
            _teamHub = teamHub;
            _mapper = mapper;
        }
        public void Handle(TeamChangedEvent domainEvent)
        {
            var team = _repository.Get(new FullTeamById(domainEvent.TeamId));
            var teamModel = _mapper.Map<Team, TeamViewModel>(team);

            _teamHub.Clients.All.TeamChanged(teamModel);
        }
    }
}