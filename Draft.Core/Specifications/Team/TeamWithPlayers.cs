using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class TeamWithPlayers : BaseSpecification<Team>
    {
        public TeamWithPlayers(int teamId) : base(t => t.Id == teamId)
        {
            AddInclude(t => t.Players);
            AddInclude(t => t.Starters);
        }
    }
}