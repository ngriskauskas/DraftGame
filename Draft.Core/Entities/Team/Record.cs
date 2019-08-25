using System;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Record : Entity, IEquatable<Record>
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }

        public Record(int wins, int losses, int ties)
        {
            Wins = wins;
            Losses = losses;
            Ties = ties;
        }

        public bool Equals(Record other)
        {
            return (Wins + (Ties / 2)) == (other.Wins + (other.Ties / 2));
        }

        public static bool operator <(Record r1, Record r2)
        {
            return (r1.Wins + (r1.Ties / 2)) < (r2.Wins + (r2.Ties / 2));
        }

        public static bool operator >(Record r1, Record r2)
        {
            return (r1.Wins + (r1.Ties / 2)) > (r2.Wins + (r2.Ties / 2));
        }
    }
}