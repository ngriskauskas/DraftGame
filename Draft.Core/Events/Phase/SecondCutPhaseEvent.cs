using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class SecondCutPhaseEvent : BasePhaseEvent
    {

        public SecondCutPhaseEvent(Phase phase) : base(phase)
        {
        }
    }
}