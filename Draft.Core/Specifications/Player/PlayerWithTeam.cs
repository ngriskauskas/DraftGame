using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class PlayerWithTeam : BaseSpecification<Player>
    {
        public PlayerWithTeam(int playerId) : base(p => p.Id == playerId)
        {
            AddInclude(p => p.Team);
        }
    }
}