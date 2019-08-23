using Draft.Core.Entities;

namespace Draft.Core.Events
{
    public class DraftPhaseEvent : BasePhaseEvent
    {
        public DraftPhaseEvent(Phase phase) : base(phase) { }
    }
}