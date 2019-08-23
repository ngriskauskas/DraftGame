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
        private readonly IDomainEventDispatcher _dispatcher;

        public PhaseDispatcher(IDomainEventDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        public void Handle(PhaseStartedEvent domainEvent)
        {
            Dispatch(domainEvent.Phase);
        }
        private void Dispatch(Phase phase)
        {

            switch (phase.PhaseType)
            {
                case PhaseType.PreDraft:
                    _dispatcher.Dispatch(new PreDraftPhaseEvent(phase));
                    break;
                case PhaseType.Draft:
                    _dispatcher.Dispatch(new DraftPhaseEvent(phase));
                    break;
                default:
                    break;
            }

        }


    }
}