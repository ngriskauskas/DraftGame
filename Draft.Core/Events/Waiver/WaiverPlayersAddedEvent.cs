using System.Collections.Generic;
using Draft.Core.Entities;
using Draft.Core.SharedKernel;

namespace Draft.Core.Events
{
    public class WaiverPlayersAddedEvent : DomainEvent
    {
        public IEnumerable<Player> Players { get; set; }

        public WaiverPlayersAddedEvent(IEnumerable<Player> players)
        {
            Players = players;
        }
    }
}