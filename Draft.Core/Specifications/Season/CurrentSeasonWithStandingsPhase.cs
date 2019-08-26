using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class CurrentSeasonWithStandingsPhase : CurrentSeason
    {
        public CurrentSeasonWithStandingsPhase() : base()
        {
            AddInclude(s => s.Phases);
            AddInclude($"{nameof(Season.Standings)}.{nameof(Standings.Teams)}.{nameof(ArcTeam.Record)}");
            AddInclude($"{nameof(Season.Standings)}.{nameof(Standings.Champion)}");
        }
    }
}