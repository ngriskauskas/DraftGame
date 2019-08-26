using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class CurrentSeasonWithStandingsTeams : CurrentSeason
    {
        public CurrentSeasonWithStandingsTeams() : base()
        {
            AddInclude($"{nameof(Season.Standings)}.{nameof(Standings.Teams)}.{nameof(ArcTeam.Team)}");
        }
    }
}