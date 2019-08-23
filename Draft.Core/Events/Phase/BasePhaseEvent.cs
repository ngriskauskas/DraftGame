using Draft.Core.Entities;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public abstract class BasePhaseEvent : DomainEvent
    {
        public Phase Phase { get; }
        protected BasePhaseEvent(Phase phase)
        {
            Phase = phase;
        }
    }
}