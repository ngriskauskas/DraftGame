using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class CurrentSeason : BaseSpecification<Season>
    {
        public CurrentSeason() : base(s => s.IsActive && !s.IsCompleted) { }
    }
}