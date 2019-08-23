using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class FirstRegGamePhaseEvent : BasePhaseEvent
    {

        public FirstRegGamePhaseEvent(Phase phase) : base(phase)
        {
        }
    }
}