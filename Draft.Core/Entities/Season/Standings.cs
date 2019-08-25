using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Standings : Entity
    {
        public ICollection<ArcTeam> Teams { get; private set; } = new List<ArcTeam>();
        public ArcTeam Champion { get; set; }
        public ArcTeam EastChamp { get; set; }
        public ArcTeam WestChamp { get; set; }

        [NotMapped]
        public List<ArcTeam> EastStandings
        {
            get =>
                Teams
                .Where(t => t.Division == Division.East)
                .OrderByDescending(t => t.Record.Wins + t.Record.Ties / 2)
                .ToList();
        }

        [NotMapped]
        public List<ArcTeam> WestStandings
        {
            get =>
                Teams
                .Where(t => t.Division == Division.West)
                .OrderByDescending(t => t.Record.Wins + t.Record.Ties / 2)
                .ToList();
        }

        private Standings() { }
        public Standings(List<ArcTeam> teams)
        {
            Teams = teams;
        }

        public void Update(IEnumerable<ArcTeam> teams)
        {
            foreach (var team in teams)
            {
                var arcTeam = Teams.SingleOrDefault(ac => ac.Team == team.Team);
                if (arcTeam == null)
                    Teams.Add(team);
                else
                {
                    Teams.Remove(arcTeam);
                    Teams.Add(team);
                }
            }
        }



    }
}