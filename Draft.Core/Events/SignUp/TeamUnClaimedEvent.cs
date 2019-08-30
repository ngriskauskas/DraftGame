using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class TeamUnClaimedEvent : DomainEvent
    {
        public int TeamId { get; set; }

        public TeamUnClaimedEvent(int teamId)
        {
            TeamId = teamId;
        }
    }
}