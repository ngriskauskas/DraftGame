using System.Collections.Generic;

namespace Draft.Core.Entities
{
    public static class PositionExtensions
    {
        public static Role GetRole(this Position position)
        {
            return roleMap[position];
        }
        public static SubRole GetSubRole(this Position position)
        {
            return subRoleMap[position];
        }
        private static Dictionary<Position, Role> roleMap = new Dictionary<Position, Role>()
            {
                {Position.QB, Role.Offense},
                {Position.RB, Role.Offense},
                {Position.WR, Role.Offense},
                {Position.TE, Role.Offense},
                {Position.T, Role.Offense},
                {Position.G, Role.Offense},
                {Position.C, Role.Offense},
                {Position.K, Role.Offense},
                {Position.DE, Role.Defense},
                {Position.DT, Role.Defense},
                {Position.LB, Role.Defense},
                {Position.CB, Role.Defense},
                {Position.S, Role.Defense},
                {Position.P, Role.Defense},
            };

        private static Dictionary<Position, SubRole> subRoleMap = new Dictionary<Position, SubRole>()
        {
            {Position.QB, SubRole.OffQB},
            {Position.RB, SubRole.OffRush},
            {Position.WR, SubRole.OffPass},
            {Position.TE, SubRole.OffBoth},
            {Position.T, SubRole.OffLine},
            {Position.G, SubRole.OffLine},
            {Position.C, SubRole.OffLine},
            {Position.K, SubRole.OffSpecial},
            {Position.DE, SubRole.DefLine},
            {Position.DT, SubRole.DefLine},
            {Position.LB, SubRole.DefLB},
            {Position.CB, SubRole.DefBack},
            {Position.S, SubRole.DefBack},
            {Position.P, SubRole.DefSpecial}
        };
    }
}