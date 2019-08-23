using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Season : Aggregate
    {
        public ICollection<Phase> Phases { get; private set; } = new List<Phase>();
        public DateTime StartDate { get; private set; }
        public Standings Standings { get; private set; }
        public Draft Draft { get; private set; }
        public bool IsCompleted { get; private set; }
        public bool IsActive { get; private set; }

        public Phase CurPhase => Phases.SingleOrDefault(p => p.IsActive);

        private Season(bool isCompleted, bool isActive)
        {
            IsCompleted = isCompleted;
            IsActive = isActive;
        }
        public Season(Standings standings, DateTime startDate, List<Phase> phases, bool isCompleted, bool isActive) : this(isCompleted, isActive)
        {
            Standings = standings;
            StartDate = startDate;
            Phases = phases;
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

            Phases.Single(p => p.PhaseType == PhaseType.PreDraft).Activate();
        }

        public void CompletePhase()
        {
            var nextPhase = Phases.Single(p => (int)p.PhaseType == (int)CurPhase.PhaseType + 1);
            CurPhase.Complete();
            nextPhase.Activate();
        }
    }
}