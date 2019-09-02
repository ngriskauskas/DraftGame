using Draft.Core.Entities;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class TeamChangedEvent : DomainEvent
    {
        public int TeamId { get; set; }

        public TeamChangedEvent(int teamId)
        {
            TeamId = teamId;
        }
    }
}