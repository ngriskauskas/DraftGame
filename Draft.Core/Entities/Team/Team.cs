using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Team : Aggregate
    {

        public ICollection<Player> Players { get; private set; }
        public ICollection<Player> Starters { get; private set; }
        public string Name { get; private set; }
        public Division Division { get; private set; }
        public Record Record { get; private set; }
        public int OffRating { get; private set; }
        public int DefRating { get; private set; }

        public int RosterSize => Players.Where(p => !p.IsInjured).Count();

        private Team(string name, Division division)
        {
            Name = name;
            Division = division;
        }
        public Team(string name, Division division, Record record, List<Player> players) : this(name, division)
        {
            Record = record;
            Players = players;
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            UpdateStarters();
            Events.Add(new TeamChangedEvent(Id));
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
            UpdateStarters();
            Events.Add(new TeamChangedEvent(Id));
        }
        public void ResetRecord()
        {
            Record.Wins = 0;
            Record.Losses = 0;
            Record.Ties = 0;
        }
        private void UpdateRating()
        {
            OffRating = RatingExtensions.CalcOffRating(Starters);
            DefRating = RatingExtensions.CalcDefRating(Starters);
        }
        public void UpdateStarters()
        {
            var result = new List<Player>();

            foreach (Position pos in Enum.GetValues(typeof(Position)))
                result.AddRange
                (
                    Players
                        .Where(p => p.Position.Equals(pos))
                        .OrderByDescending(p => p.Rating)
                        .Take(startPosPlayers[pos])
                );

            Starters = result;
            UpdateRating();
        }

        private static Dictionary<Position, int> minPosPlayers = new Dictionary<Position, int>()
        {
            {Position.P, 1},
            {Position.K, 1},
            {Position.QB, 2},
            {Position.RB, 3},
            {Position.WR, 3},
            {Position.TE, 2},
            {Position.T, 3},
            {Position.G, 3},
            {Position.C, 2},
            {Position.DE, 3},
            {Position.DT, 3},
            {Position.LB, 4},
            {Position.S, 3},
            {Position.CB, 3},
        };
        private static Dictionary<Position, int> maxPosPlayers = new Dictionary<Position, int>()
        {
            {Position.P, 1},
            {Position.K, 1},
            {Position.QB, 3},
            {Position.RB, 6},
            {Position.WR, 6},
            {Position.TE, 4},
            {Position.T, 6},
            {Position.G, 6},
            {Position.C, 4},
            {Position.DE, 6},
            {Position.DT, 6},
            {Position.LB, 6},
            {Position.S, 6},
            {Position.CB, 6},
        };

        private static Dictionary<Position, int> startPosPlayers = new Dictionary<Position, int>()
        {
            {Position.P, 1},
            {Position.K, 1},
            {Position.QB, 1},
            {Position.RB, 2},
            {Position.WR, 2},
            {Position.TE, 1},
            {Position.T, 2},
            {Position.G, 2},
            {Position.C, 1},
            {Position.DE, 2},
            {Position.DT, 2},
            {Position.LB, 3},
            {Position.S, 2},
            {Position.CB, 2},
        };

    }
}