using System.Collections.Generic;
using System.Linq;

namespace Draft.Core.Entities
{
    public static class RosterRatingExtensions
    {
        public static int CalcOffRating(this Roster roster)
        {
            return BaseOff(roster.Starters) + BonusOff(roster.Starters);
        }

        public static int CalcDefRating(this Roster roster)
        {
            return BaseDef(roster.Starters) + BonusDef(roster.Starters);
        }

        private static int BaseOff(IEnumerable<Player> starters)
        {
            return starters
                .Where(p => p.Position.Role == Role.Offense)
                .Sum(p => p.Rating);
        }

        private static int BaseDef(IEnumerable<Player> starters)
        {
            return starters
                .Where(p => p.Position.Role == Role.Defense)
                .Sum(p => p.Rating);
        }
        private static int BonusOff(IEnumerable<Player> starters)
        {
            int total = 0;
            int def = 0;
            RunBonus(starters, ref total, ref def);
            total += PassBonus(starters);
            return total;
        }

        private static int BonusDef(IEnumerable<Player> starters)
        {
            int total = 0;
            int off = 0;

            RunBonus(starters, ref off, ref total);
            total += DefBonus(starters);
            return total;

        }

        private static void RunBonus(IEnumerable<Player> starters, ref int offBonus, ref int defBonus)
        {
            if (TotalRatingInPositions(starters, Position.G, Position.T, Position.C) < 21)
                return;
            if (TotalRatingInPositions(starters, Position.TE) < 5)
                return;
            if (TotalRatingInPositions(starters, Position.RB) < 15)
                return;

            int total = TotalRatingInPositions(starters, Position.G, Position.T, Position.C, Position.TE, Position.RB);

            if (total < 44)
                return;
            else if (total >= 63)
            {
                offBonus += 3;
                defBonus += 2;
            }
            else if (total >= 58)
            {
                offBonus += 2;
                defBonus += 2;
            }
            else if (total >= 52)
            {
                offBonus += 2;
                defBonus++;
            }
            else if (total >= 48)
            {
                offBonus += 2;
            }
            else if (total >= 44)
            {
                offBonus++;
            }
        }

        private static int PassBonus(IEnumerable<Player> starters)
        {
            if (TotalRatingInPositions(starters, Position.G, Position.T, Position.C) < 21)
                return 0;
            if (TotalRatingInPositions(starters, Position.TE, Position.WR) < 16)
                return 0;
            if (TotalRatingInPositions(starters, Position.QB) < 11)
                return 0;

            int total = TotalRatingInPositions(starters, Position.G, Position.T, Position.C, Position.TE, Position.WR, Position.QB);

            if (total < 52)
                return 0;
            else if (total >= 75)
                return 5;
            else if (total >= 68)
                return 4;
            else if (total >= 62)
                return 3;
            else if (total >= 57)
                return 2;
            else
                return 1;
        }

        private static int DefBonus(IEnumerable<Player> starters)
        {
            if (TotalRatingInPositions(starters, Position.DE, Position.DT) < 22)
                return 0;
            if (TotalRatingInPositions(starters, Position.LB) < 16)
                return 0;
            if (TotalRatingInPositions(starters, Position.CB, Position.S) < 22)
                return 0;

            int total = 0;

            total += DefLineBonus(starters);
            total += DefSecondaryBonus(starters);
            total += LineBackerBonus(starters);

            return total;
        }

        private static int DefLineBonus(IEnumerable<Player> starters)
        {
            int total = TotalRatingInPositions(starters, Position.DE, Position.DT);

            if (total < 28)
                return 0;
            else if (total >= 34)
                return 2;
            else
                return 1;
        }
        private static int DefSecondaryBonus(IEnumerable<Player> starters)
        {
            int total = TotalRatingInPositions(starters, Position.CB, Position.S);

            if (total < 28)
                return 0;
            else if (total >= 34)
                return 2;
            else
                return 1;
        }
        private static int LineBackerBonus(IEnumerable<Player> starters)
        {
            int total = TotalRatingInPositions(starters, Position.LB);

            if (total < 21)
                return 0;
            else if (total >= 25)
                return 2;
            else
                return 1;
        }

        private static int TotalRatingInPositions(IEnumerable<Player> players, params Position[] positions)
        {
            return players.Where(p => positions.Contains(p.Position.Position)).Sum(p => p.Rating);
        }

    }
}