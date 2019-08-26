using Draft.Core.Entities;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class StandingsChangedEvent : DomainEvent
    {
        public Standings Standings { get; }
        public StandingsChangedEvent(Standings standings)
        {
            Standings = standings;
        }
    }
}