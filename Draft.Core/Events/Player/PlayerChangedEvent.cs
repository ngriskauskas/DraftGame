using Draft.Core.Entities;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class PlayerChangedEvent : DomainEvent
    {
        public Player Player { get; set; }

        public PlayerChangedEvent(Player player)
        {
            Player = player;
        }
    }
}