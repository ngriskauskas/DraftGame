using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class FirstCutPhaseEvent : BasePhaseEvent
    {

        public FirstCutPhaseEvent(Phase phase) : base(phase)
        {
        }
    }
}