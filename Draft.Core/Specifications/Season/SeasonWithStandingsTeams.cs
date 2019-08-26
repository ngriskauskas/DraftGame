using System;
using System.Linq.Expressions;
using Draft.Core.Entities;
using Draft.Core.Interfaces;

namespace Draft.Core.Specifications
{
    public class SeasonWithStandingsTeams : BaseSpecification<Season>
    {
        public SeasonWithStandingsTeams(int id) : base(s => s.Id == id)
        {
            AddInclude($"{nameof(Season.Standings)}.{nameof(Standings.Teams)}.{nameof(ArcTeam.Team)}");
        }
    }
}