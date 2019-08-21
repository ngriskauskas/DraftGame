using System.Collections.Generic;

namespace Draft.Core.Entities
{
    public enum Position
    {
        QB,
        RB,
        TE,
        LB,
        T,
        G,
        C,
        WR,
        DE,
        DT,
        CB,
        S,
        P,
        K
    }
    public enum SubRole
    {
        OffBoth,
        OffRush,
        OffPass,
        OffLine,
        OffQB,
        OffSpecial,
        DefLB,
        DefBase,
        DefLine,
        DefBack,
        DefSpecial
    }
    public enum Role
    {
        Offense,
        Defense
    }

}