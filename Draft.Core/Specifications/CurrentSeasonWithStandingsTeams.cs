using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class CurrentSeasonWithStandingsTeams : BaseSpecification<Season>
    {
        public CurrentSeasonWithStandingsTeams() : base(s => s.IsActive && !s.IsCompleted)
        {
            AddInclude($"{nameof(Season.Standings)}.{nameof(Standings.Teams)}.{nameof(ArcTeam.Team)}");
        }
    }
}