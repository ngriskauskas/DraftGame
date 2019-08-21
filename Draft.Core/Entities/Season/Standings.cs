using System.Collections.Generic;
using System.Linq;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Standings : Entity
    {
        private readonly List<ArcTeam> _teams = new List<ArcTeam>();
        public ArcTeam Champion { get; set; }
        public ArcTeam EastChamp { get; set; }
        public ArcTeam WestChamp { get; set; }
        public List<ArcTeam> EastStandings =>
            _teams
            .Where(t => t.Division == Division.East)
            .OrderByDescending(t => t.Record.Wins + t.Record.Ties / 2)
            .ToList();

        public List<ArcTeam> WestStandings =>
            _teams
            .Where(t => t.Division == Division.West)
            .OrderByDescending(t => t.Record.Wins + t.Record.Ties / 2)
            .ToList();

        private Standings() { }
        public Standings(List<ArcTeam> teams)
        {
            _teams = teams;
        }



    }
}