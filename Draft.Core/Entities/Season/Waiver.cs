using System.Collections.Generic;
using System.Collections.ObjectModel;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Waiver : Entity
    {
        public List<Player> Players { get; private set; }


        public void AddPlayer(Player player)
        {
            Players.Add(player);
            Events.Add(new WaiverPlayerAddedEvent(player));
        }
        public void AddPlayers(IEnumerable<Player> players)
        {
            Players.AddRange(players);
        }
        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
            Events.Add(new WaiverPlayerRemovedEvent(player.Id));

        }
    }
}