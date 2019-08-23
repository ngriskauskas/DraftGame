using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class ChampPhaseEvent : BasePhaseEvent
    {

        public ChampPhaseEvent(Phase phase) : base(phase)
        {

        }
    }
}