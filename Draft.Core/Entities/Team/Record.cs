using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Record : Entity
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
    }
}