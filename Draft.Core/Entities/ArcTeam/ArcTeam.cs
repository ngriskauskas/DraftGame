using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class ArcTeam : Aggregate
    {
        public string Name { get; }
        public Division Division { get; }
        public GameTeam Game { get; }
        public Team Team { get; }
        public Record Record { get; }
        public Roster Roster { get; }
        public int OffRating { get; }
        public int DefRating { get; }

    }
}