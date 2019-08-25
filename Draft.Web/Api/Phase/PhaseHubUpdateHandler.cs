using System;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api.Handlers
{
    public class PhaseHubUpdateHandler : IHandle<PhaseStartedEvent>, IHandle<DateChangedEvent>
    {
        private readonly IHubContext<PhaseHub, IPhaseHub> _phaseHub;

        public PhaseHubUpdateHandler(IHubContext<PhaseHub, IPhaseHub> phaseHub)
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