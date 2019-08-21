using System;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Phase : Entity
    {
        public PhaseType PhaseType { get; }
        public DateTime Date { get; }
        public int MaxRosterSize { get; }
        public bool CanTrade { get; }
        public bool IsComplete { get; set; } = false;
        public bool IsActive { get; set; } = false;


        public Phase(PhaseType type, DateTime date, int maxRosterSize, bool canTrade)
        {
            PhaseType = type;
            Date = date;
            MaxRosterSize = maxRosterSize;
            CanTrade = canTrade;
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