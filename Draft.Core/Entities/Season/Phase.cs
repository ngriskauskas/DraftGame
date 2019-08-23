using System;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Phase : Entity
    {
        public PhaseType PhaseType { get; private set; }
        public DateTime Date { get; private set; }
        public int MaxRosterSize { get; private set; }
        public bool CanTrade { get; private set; }
        public bool IsComplete { get; private set; } = false;
        public bool IsActive { get; private set; } = false;

        private Phase(int maxRosterSize, bool canTrade)
        {
            MaxRosterSize = maxRosterSize;
            CanTrade = canTrade;
        }
        public Phase(PhaseType phaseType, DateTime date, int maxRosterSize, bool canTrade) : this(maxRosterSize, canTrade)
        {
            PhaseType = phaseType;
            Date = date;
        }

        public void Activate()
        {
            IsActive = true;
            Events.Add(new PhaseStartedEvent(this));
        }
        public void Complete()
        {
            IsComplete = true;
            IsActive = false;
        }
    }

    public enum PhaseType
    {
        PreDraft,
        Draft,
        TrainStart,
        FirstCut,
        SecondCut,
        FinalCut,
        FirstRegGame,
        SecondRegGame,
        DivChamp,
        Champ,
        EndSeason,
        Retirement
    }

}