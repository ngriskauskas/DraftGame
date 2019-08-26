using Draft.Core.Entities;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class TeamAddedPlayerEvent : DomainEvent
    {
        public int TeamId { get; set; }
        public Player Player { get; set; }

        public TeamAddedPlayerEvent(int teamId, Player player)
        {
            TeamId = teamId;
            Player = player;
        }
    }
}