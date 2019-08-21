using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Team : Aggregate
    {
        public string Name { get; private set; }
        public Division Division { get; private set; }
        public Roster Roster { get; }
        public Record Record { get; }
        public int OffRating { get; private set; }
        public int DefRating { get; private set; }

        public Team(string name, Division division)
        {
            Name = name;
            Division = division;
        }

        public void UpdateRating()
        {
            OffRating = Roster.CalcOffRating();
            DefRating = Roster.CalcDefRating();
        }

    }
}