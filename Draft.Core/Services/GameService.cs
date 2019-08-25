using System;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;

namespace Draft.Core.Services
{
    public class GameService : IHandle<GameStartedEvent>
    {
        private enum HomeAdv
        {
            OffAdv,
            DefAdv
        }
        private readonly IResourceProvider _resources;
        private Game _game;

        public GameService(IResourceProvider resources)
        {
            _resources = resources;
        }
        public void Handle(GameStartedEvent domainEvent)
        {
            _game = domainEvent.Game;
            CalcScores();
        }
        private void CalcScores()
        {
            var homeAdv = (HomeAdv)Enum.GetValues(typeof(HomeAdv)).GetValue(new Random().Next(1));

            int homeRoll = Roll2() + (homeAdv == HomeAdv.OffAdv ? 1 : 0);
            int awayRoll = Roll2() - (homeAdv == HomeAdv.DefAdv ? 1 : 0);

            homeRoll = Clamp(homeRoll, 2, 12);
            awayRoll = Clamp(awayRoll, 2, 12);

            int homeRatDif = _game.HomeTeam.OffRating - _game.AwayTeam.DefRating;
            int awayRatDif = _game.AwayTeam.OffRating - _game.HomeTeam.DefRating;

            homeRatDif = Clamp(homeRatDif, -50, 60);
            awayRatDif = Clamp(awayRatDif, -50, 60);

            int homeScore = _resources.GetGameScores()[60 - homeRatDif][homeRoll - 2];
            int awayScore = _resources.GetGameScores()[60 - awayRatDif][awayRoll - 2];

            _game.Complete(homeScore, awayScore);
        }

        private int Roll2()
        {
            var rng = new Random();
            return rng.Next(1, 6) + rng.Next(1, 6);
        }
        private int Clamp(int val, int min, int max)
        {
            return (val < min) ? min : (val > max) ? max : val;
        }

    }
}