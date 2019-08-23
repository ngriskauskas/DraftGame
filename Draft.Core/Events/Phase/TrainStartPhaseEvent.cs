using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class TrainStartPhaseEvent : BasePhaseEvent
    {
        public TrainStartPhaseEvent(Phase phase) : base(phase)
        {
        }
    }
}