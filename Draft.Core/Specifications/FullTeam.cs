using System;
using System.Linq.Expressions;
using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class FullTeam : BaseSpecification<Team>
    {
        public FullTeam() : base(null)
        {
            AddInclude(t => t.Record);
            AddInclude(t => t.Players);
        }
    }
}