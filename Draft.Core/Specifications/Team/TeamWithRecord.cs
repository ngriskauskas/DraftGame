using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class TeamWithRecord : BaseSpecification<Team>
    {
        public TeamWithRecord() : base(null)
        {
            AddInclude(t => t.Record);
        }
    }
}