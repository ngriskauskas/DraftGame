using System.Collections.Generic;
using System.Linq;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Standings : Entity
    {
        private readonly List<ArcTeam> teams = new List<ArcTeam>();
        public ArcTeam Champion { get; set; }
        public ArcTeam EastChamp { get; set; }
        public ArcTeam WestChamp { get; set; }
        public List<Team> EastStandings =>
            teams
            .Where(t => t.Division == Division.East)
            .OrderByDescending(t => t.Record.Wins + t.Record.Ties / 2)
            .Select(t => t.Team)
            .ToList();

        public List<Team> WestStandings =>
            teams
            .Where(t => t.Division == Division.East)
            .OrderByDescending(t => t.Record.Wins + t.Record.Ties / 2)
            .Select(t => t.Team)
            .ToList();


    }
}