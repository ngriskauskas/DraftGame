using System;
using System.Collections.Generic;
using System.Linq;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Season : Aggregate
    {
        private readonly List<Phase> _phases = new List<Phase>();

        public DateTime StartDate { get; }
        public Standings Standings { get; }
        public Draft Draft { get; set; }
        public bool IsCompleted { get; private set; }
        public bool IsActive { get; private set; }

        public Phase CurPhase => _phases.SingleOrDefault(p => p.IsActive);

        public Season(DateTime startDate, bool isCompleted, bool isActive)
        {
            StartDate = startDate;
            IsCompleted = isCompleted;
            IsActive = isActive;
        }




    }
}