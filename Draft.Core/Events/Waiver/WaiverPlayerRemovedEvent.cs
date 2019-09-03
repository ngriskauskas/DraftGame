using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class WaiverPlayerRemovedEvent : DomainEvent
    {
        public int PlayerId { get; set; }

        public WaiverPlayerRemovedEvent(int playerId)
        {
            PlayerId = playerId;
        }
    }
}