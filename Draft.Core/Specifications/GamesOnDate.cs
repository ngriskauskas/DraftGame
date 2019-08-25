using System;
using System.Linq.Expressions;
using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class GamesOnDate : BaseSpecification<Game>
    {
        public GamesOnDate(DateTime date) : base(g => g.Date == date)
        {
            AddInclude(g => g.GameTeams);
            AddInclude($"{nameof(Game.GameTeams)}.{nameof(GameTeam.Team)}.{nameof(Team.Record)}");
            AddInclude($"{nameof(Game.GameTeams)}.{nameof(GameTeam.Team)}.{nameof(Team.Players)}");
        }
    }

}
