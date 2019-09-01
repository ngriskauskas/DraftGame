using System;
using System.Linq.Expressions;
using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class FullTeamById : BaseSpecification<Team>
    {
        public FullTeamById(int teamId) : base(t => t.Id == teamId)
        {
            AddInclude(t => t.Record);
            AddInclude(t => t.Players);
            AddInclude(t => t.Starters);
        }
    }
}