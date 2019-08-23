using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class FinalCutPhaseEvent : BasePhaseEvent
    {

        public FinalCutPhaseEvent(Phase phase) : base(phase)
        {
        }
    }
}