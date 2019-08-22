using System;
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


        public Phase(PhaseType type, DateTime date, int maxRosterSize, bool canTrade)
        {
            PhaseType = type;
            Date = date;
            MaxRosterSize = maxRosterSize;
            CanTrade = canTrade;
        }

        public void Activate()
        {
            IsActive = true;
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