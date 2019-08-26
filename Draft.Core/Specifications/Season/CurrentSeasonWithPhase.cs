namespace Draft.Core.Specifications
{
    public class CurrentSeasonWithPhase : CurrentSeason
    {
        public CurrentSeasonWithPhase() : base()
        {
            AddInclude(s => s.Phases);
        }
    }
}