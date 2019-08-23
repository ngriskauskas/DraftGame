using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class DivChampPhaseEvent : BasePhaseEvent
    {

        public DivChampPhaseEvent(Phase phase) : base(phase)
        {
        }
    }
}