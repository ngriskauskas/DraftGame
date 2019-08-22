using System;
using Autofac;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Services;

namespace Draft.Core.Handlers
{
    public class PhaseDispatcher : IHandle<PhaseStartedEvent>
    {
        private readonly IComponentContext _container;

        public PhaseDispatcher(IComponentContext container)
        {
            _container = container;
        }
        public void Handle(PhaseStartedEvent domainEvent)
        {
            Dispatch(domainEvent.Phase);
        }
        private void Dispatch(Phase phase)
        {
            Type serviceType;

            switch (phase.PhaseType)
            {
                case PhaseType.PreDraft:
                    serviceType = typeof(PreDraftService);
                    break;
                default:
                    serviceType = null;
                    break;
            }

            var phaseService = (IPhaseService)Activator.CreateInstance(serviceType, phase);
            phaseService.Handle();
        }
    }
}