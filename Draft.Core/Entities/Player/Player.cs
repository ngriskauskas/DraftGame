using System.Collections.Generic;
using System.Collections.ObjectModel;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Player : Aggregate
    {

        private readonly List<Injury> _injuries = new List<Injury>();


        public int VeteranRating { get; private set; }
        public int RookieRating { get; private set; }
        public IEnumerable<Injury> Injuries => new ReadOnlyCollection<Injury>(_injuries);
        public PlayerPosition Position { get; set; }
        public Team Team { get; set; }
        public bool IsRetired { get; set; } = false;
        public int Experience { get; set; } = 0;


        private Player(int rookieRating, int veteranRating)
        {
            RookieRating = rookieRating;
            VeteranRating = veteranRating;
        }
        public Player(Team team, PlayerPosition position, int rookieRating, int veteranRating)
            : this(rookieRating, veteranRating)
        {
            Team = team;
            Position = position;
        }


        public bool IsRookie => Experience == 0;
        public int Rating => IsRookie ? RookieRating : VeteranRating;
    }
}