using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class PlayersWithTeam : BaseSpecification<Player>
    {
        public PlayersWithTeam() : base(null)
        {
            AddInclude(p => p.Team);
        }
    }
}