using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class EndSeasonPhaseEvent : BasePhaseEvent
    {

        public EndSeasonPhaseEvent(Phase phase) : base(phase)
        {
        }
    }
}