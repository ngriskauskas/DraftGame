using System;
using System.Collections.Generic;
using System.Linq;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Season : Aggregate
    {
        private readonly List<Phase> _phases = new List<Phase>();

        public DateTime StartDate { get; private set; }
        public Standings Standings { get; private set; }
        public Draft Draft { get; private set; }
        public bool IsCompleted { get; private set; }
        public bool IsActive { get; private set; }

        public Phase CurPhase => _phases.SingleOrDefault(p => p.IsActive);

        private Season(bool isCompleted, bool isActive)
        {
            IsCompleted = isCompleted;
            IsActive = isActive;
        }
        public Season(Standings standings, DateTime startDate, bool isCompleted, bool isActive) : this(isCompleted, isActive)
        {
            Standings = standings;
            StartDate = startDate;
        }

        public void Complete()
        {
            IsCompleted = true;
            IsActive = false;
            Events.Add(new SeasonCompletedEvent(this));
        }

        public void Activate()
        {
            IsActive = true;
            Events.Add(new SeasonStartedEvent(this));
        }




    }
}