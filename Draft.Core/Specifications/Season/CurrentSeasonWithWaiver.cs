using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class CurrentSeasonWithWaiver : CurrentSeason
    {
        public CurrentSeasonWithWaiver() : base()
        {
            AddInclude($"{nameof(Season.Waiver)}.{nameof(Waiver.Players)}");
        }
    }
}