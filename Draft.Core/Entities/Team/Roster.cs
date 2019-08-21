// using System;
// using System.Collections.Generic;
// using System.Collections.ObjectModel;
// using System.Linq;
// using Draft.Core.SharedKernel;

// namespace Draft.Core.Entities
// {
//     public class Roster : Entity
//     {
//         private readonly List<Player> _players = new List<Player>();
//         private List<Player> _starters = new List<Player>();

//         public IEnumerable<Player> Players => new ReadOnlyCollection<Player>(_players);
//         public IEnumerable<Player> Starters => new ReadOnlyCollection<Player>(_starters);

//         private Roster() { }
//         public Roster(List<Player> players)
//         {
//             _players = players;
//         }

//         private void UpdateStarters()
//         {
//             var result = new List<Player>();

//             foreach (Position pos in Enum.GetValues(typeof(Position)))
//                 result.AddRange
//                 (
//                     _players
//                         .Where(p => p.Position.Equals(pos))
//                         .OrderByDescending(p => p.Rating)
//                         .Take(startPosPlayers[pos])
//                 );

//             _starters = result;
//         }

//         private static Dictionary<Position, int> minPosPlayers = new Dictionary<Position, int>()
//         {
//             {Position.P, 1},
//             {Position.K, 1},
//             {Position.QB, 2},
//             {Position.RB, 3},
//             {Position.WR, 3},
//             {Position.TE, 2},
//             {Position.T, 3},
//             {Position.G, 3},
//             {Position.C, 2},
//             {Position.DE, 3},
//             {Position.DT, 3},
//             {Position.LB, 4},
//             {Position.S, 3},
//             {Position.CB, 3},
//         };
//         private static Dictionary<Position, int> maxPosPlayers = new Dictionary<Position, int>()
//         {
//             {Position.P, 1},
//             {Position.K, 1},
//             {Position.QB, 3},
//             {Position.RB, 6},
//             {Position.WR, 6},
//             {Position.TE, 4},
//             {Position.T, 6},
//             {Position.G, 6},
//             {Position.C, 4},
//             {Position.DE, 6},
//             {Position.DT, 6},
//             {Position.LB, 6},
//             {Position.S, 6},
//             {Position.CB, 6},
//         };

//         private static Dictionary<Position, int> startPosPlayers = new Dictionary<Position, int>()
//         {
//             {Position.P, 1},
//             {Position.K, 1},
//             {Position.QB, 1},
//             {Position.RB, 2},
//             {Position.WR, 2},
//             {Position.TE, 1},
//             {Position.T, 2},
//             {Position.G, 2},
//             {Position.C, 1},
//             {Position.DE, 2},
//             {Position.DT, 2},
//             {Position.LB, 3},
//             {Position.S, 2},
//             {Position.CB, 2},
//         };

//     }
// }