using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class CurrentSeasonWithWaiver : BaseSpecification<Season>
    {
        public CurrentSeasonWithWaiver() : base(s => s.IsActive && !s.IsCompleted)
        {
            AddInclude($"{nameof(Season.Waiver)}.{nameof(Waiver.Players)}");
        }
    }
}