using System.Collections.Generic;
using System.Collections.ObjectModel;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class ArcTeam : Aggregate
    {
        public ICollection<Player> Players { get; private set; }
        public ICollection<Player> Starters { get; private set; }
        public string Name { get; private set; }
        public Division Division { get; private set; }
        public GameTeam GameTeam { get; private set; }
        public Team Team { get; private set; }
        public Record Record { get; private set; }
        public int OffRating { get; private set; }
        public int DefRating { get; private set; }

        private ArcTeam() { }
        public ArcTeam(GameTeam gameTeam) : this(gameTeam.Team)
        {
            GameTeam = gameTeam;
        }
        public ArcTeam(Team team)
        {
            Team = team;
            Name = team.Name;
            Division = team.Division;
            OffRating = team.OffRating;
            DefRating = team.DefRating;
            Players = new List<Player>(team.Players);
            Starters = new List<Player>(team.Starters);
            Record = new Record(team.Record.Wins, team.Record.Losses, team.Record.Ties);
        }
    }
}