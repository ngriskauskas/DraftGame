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
        public Position Position { get; private set; }
        public Team Team { get; private set; }
        public bool IsRetired { get; set; } = false;
        public int Experience { get; set; } = 0;


        private Player(int rookieRating, int veteranRating)
        {
            RookieRating = rookieRating;
            VeteranRating = veteranRating;
        }
        public Player(Team team, Position position, int rookieRating, int veteranRating)
            : this(rookieRating, veteranRating)
        {
            Team = team;
            Position = position;
        }
        public bool IsRookie => Experience == 0;
        public int Rating => IsRookie ? RookieRating : VeteranRating;
        public bool IsInjured => _injuries.Exists(i => i.IsActive);
        public SubRole SubRole => Position.GetSubRole();
        public Role Role => Position.GetRole();

        public void Retire()
        {
            Team = null;
            IsRetired = true;
        }
    }
}