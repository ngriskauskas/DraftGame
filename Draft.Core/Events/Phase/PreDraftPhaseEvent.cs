using Draft.Core.Entities;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class PreDraftPhaseEvent : BasePhaseEvent
    {
        public PreDraftPhaseEvent(Phase phase) : base(phase) { }
    }
}