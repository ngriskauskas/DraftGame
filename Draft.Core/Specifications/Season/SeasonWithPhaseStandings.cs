using System;
using System.Linq.Expressions;
using Draft.Core.Entities;
using Draft.Core.Interfaces;

namespace Draft.Core.Specifications
{
    public class SeasonWithPhaseStandings : BaseSpecification<Season>
    {
        public SeasonWithPhaseStandings(Expression<Func<Season, bool>> criteria) : base(criteria)
        {
            AddInclude(s => s.Phases);
            AddInclude($"{nameof(Season.Standings)}.{nameof(Standings.Teams)}.{nameof(ArcTeam.Record)}");
        }
    }
}