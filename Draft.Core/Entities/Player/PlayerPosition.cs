using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class PlayerPosition : Entity
    {
        private readonly Position position;
        public Position Position => position;
        public SubRole SubRole => position.GetSubRole();
        public Role Role => position.GetRole();

        private PlayerPosition() { }

        public PlayerPosition(Position position)
        {
            this.position = position;
        }
    }
}