using System;
using System.Linq;
using AutoMapper;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Draft.Web.ViewModels;

namespace Draft.Web.Api.Handlers
{
    public class SeasonHubUpdateHandler : IHandle<PhaseStartedEvent>,
                                            IHandle<DateChangedEvent>,
                                            IHandle<StandingsChangedEvent>
    {
        private readonly IHubContext<SeasonHub, ISeasonHub> _seasonHub;
        private readonly IMapper _mapper;

        public SeasonHubUpdateHandler(IHubContext<SeasonHub, ISeasonHub> seasonHub, IMapper mapper)
        {
            _seasonHub = seasonHub;
            _mapper = mapper;
        }
        public void Handle(PhaseStartedEvent domainEvent)
        {
            var phaseViewModel = _mapper.Map<Phase, PhaseViewModel>(domainEvent.Phase);
            _seasonHub.Clients.All.UpdatePhase(phaseViewModel);
        }

        public void Handle(DateChangedEvent domainEvent)
        {
            _seasonHub.Clients.All.UpdateDate(domainEvent.Date);
        }
        public void Handle(StandingsChangedEvent domainEvent)
        {
            var standingsViewModel = _mapper.Map<Standings, StandingsViewModel>(domainEvent.Standings);
            _seasonHub.Clients.All.UpdateStandings(standingsViewModel);
        }
    }
}