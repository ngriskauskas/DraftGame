using Draft.Core.Entities;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class SeasonCompletedEvent : DomainEvent
    {
        public Season Season { get; private set; }
        public SeasonCompletedEvent(Season season)
        {
            Season = season;
        }
    }
}