using System.Collections.Generic;
using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class PlayersById : BaseSpecification<Player>
    {
        public PlayersById(List<int> playerIds) : base(p => playerIds.Contains(p.Id))
        {

        }
    }
}