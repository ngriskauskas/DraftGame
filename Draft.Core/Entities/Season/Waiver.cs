using System.Collections.Generic;
using System.Collections.ObjectModel;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Waiver : Entity
    {
        public List<Player> Players { get; private set; }

        public void AddPlayers(IEnumerable<Player> players)
        {
            Players.AddRange(players);
            Events.Add(new WaiverPlayersAddedEvent(players));
        }

        public void RemovePlayers(List<int> playerIds)
        {
            Players.RemoveAll(p => playerIds.Contains(p.Id));
            Events.Add(new WaiverPlayersRemovedEvent(playerIds));
        }
    }
}