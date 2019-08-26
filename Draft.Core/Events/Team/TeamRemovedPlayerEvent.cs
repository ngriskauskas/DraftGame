using Draft.Core.Entities;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class TeamRemovedPlayerEvent : DomainEvent
    {
        public int TeamId { get; set; }
        public int PlayerId { get; set; }

        public TeamRemovedPlayerEvent(int teamId, int playerId)
        {
            TeamId = teamId;
            PlayerId = playerId;
        }
    }
}