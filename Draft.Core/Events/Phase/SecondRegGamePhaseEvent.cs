using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class SecondRegGamePhaseEvent : BasePhaseEvent
    {

        public SecondRegGamePhaseEvent(Phase phase) : base(phase)
        {
        }
    }
}