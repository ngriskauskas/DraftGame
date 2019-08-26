using Draft.Core.Entities;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class SeasonStartedEvent : DomainEvent
    {
        public Season Season { get; private set; }
        public SeasonStartedEvent(Season season)
        {
            Season = season;
        }
    }
}