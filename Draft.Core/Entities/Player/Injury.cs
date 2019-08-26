using System;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Injury : Entity
    {
        public bool IsActive { get; private set; }
        public DateTime Date { get; set; }

        public Injury(DateTime date)
        {
            Date = date;
            IsActive = true;
        }

        public void SetNotActive()
        {
            IsActive = false;
        }
    }
}