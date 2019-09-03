using System.Collections.Generic;
using Draft.Core.Entities;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class WaiverPlayersRemovedEvent : DomainEvent
    {
        public IEnumerable<int> PlayerIds { get; set; }

        public WaiverPlayersRemovedEvent(IEnumerable<int> playerIds)
        {
            PlayerIds = playerIds;
        }
    }
}