using System.Collections.Generic;
using System.Collections.ObjectModel;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Waiver : Entity
    {
        private List<Player> _players = new List<Player>();
        public IReadOnlyCollection<Player> Players => new ReadOnlyCollection<Player>(_players);


        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }
        public void AddPlayers(IEnumerable<Player> players)
        {
            _players.AddRange(players);
        }
        public void RemovePlayer(Player player)
        {
            _players.Remove(player);
        }
    }
}