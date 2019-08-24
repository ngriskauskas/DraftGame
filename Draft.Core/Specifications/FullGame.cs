using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class FullGame : BaseSpecification<Game>
    {
        public FullGame(int id) : base(g => g.Id == id)
        {
            AddInclude(g => g.GameTeams);
            AddInclude($"{nameof(Game.GameTeams)}.{nameof(GameTeam.Team)}.{nameof(Team.Record)}");
            AddInclude($"{nameof(Game.GameTeams)}.{nameof(GameTeam.Team)}.{nameof(Team.Players)}");
        }
    }
}