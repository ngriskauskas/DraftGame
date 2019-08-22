using Draft.Core.Entities;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class PhaseStartedEvent : DomainEvent
    {
        public Phase Phase { get; }
        public PhaseStartedEvent(Phase phase)
        {
            Phase = phase;
        }
    }
}