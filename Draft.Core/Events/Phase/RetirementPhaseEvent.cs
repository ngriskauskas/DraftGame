using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class RetirementPhaseEvent : BasePhaseEvent
    {

        public RetirementPhaseEvent(Phase phase) : base(phase)
        {
        }
    }
}