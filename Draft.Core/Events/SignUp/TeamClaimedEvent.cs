using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class TeamClaimedEvent : DomainEvent
    {
        public int TeamId { get; set; }

        public TeamClaimedEvent(int teamId)
        {
            TeamId = teamId;
        }
    }
}