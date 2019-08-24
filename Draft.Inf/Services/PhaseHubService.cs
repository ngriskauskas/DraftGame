using System;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Inf.Hub;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Inf.Services
{
    public class PhaseHubService : IHandle<PhaseStartedEvent>, IHandle<DateChangedEvent>
    {
        private readonly IHubContext<PhaseHub, IPhaseHub> _phaseHub;

        public PhaseHubService(IHubContext<PhaseHub, IPhaseHub> phaseHub)
        {
            _phaseHub = phaseHub;
        }
        public void Handle(PhaseStartedEvent domainEvent)
        {
            _phaseHub.Clients.All.UpdatePhase(Enum.GetName(typeof(PhaseType), domainEvent.Phase.PhaseType));
        }

        public void Handle(DateChangedEvent domainEvent)
        {
            _phaseHub.Clients.All.UpdateDate(domainEvent.Date);
        }
    }
}