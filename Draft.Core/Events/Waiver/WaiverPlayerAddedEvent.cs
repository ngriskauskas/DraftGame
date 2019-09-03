using Draft.Core.Entities;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class WaiverPlayerAddedEvent : DomainEvent
    {
        public Player Player { get; set; }

        public WaiverPlayerAddedEvent(Player player)
        {
            Player = player;
        }
    }
}