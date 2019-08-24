using System;
using System.Collections.Generic;
using System.Linq;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Game : Aggregate
    {
        private readonly List<GameTeam> _gameTeams = new List<GameTeam>();



        public DateTime Date { get; private set; }
        public List<GameTeam> GameTeams { get; private set; }
        public int HomeScore { get; private set; } = 0;
        public int AwayScore { get; private set; } = 0;
        public bool IsCompleted { get; private set; } = false;


        public Team HomeTeam => _gameTeams.Single(t => t.TeamSide == TeamSide.Home).Team;
        public Team AwayTeam => _gameTeams.Single(t => t.TeamSide == TeamSide.Away).Team;
        public Team Winner
        {
            get
            {
                if (!IsCompleted) return null;
                if (HomeScore == AwayScore) return null;
                if (HomeScore > AwayScore) return HomeTeam;
                else return AwayTeam;
            }
        }
        private Game() { }
        public Game(DateTime date, Team homeTeam, Team awayTeam)
        {
            Date = date;
            _gameTeams.Add(new GameTeam(homeTeam, TeamSide.Home));
            _gameTeams.Add(new GameTeam(awayTeam, TeamSide.Away));
        }

        public void Complete(int homeScore, int awayScore)
        {
            HomeScore = homeScore;
            AwayScore = awayScore;
            IsCompleted = true;
            Events.Add(new GameCompletedEvent(this));
        }

        public void Play()
        {
            Events.Add(new GameStartedEvent(this));
        }

    }
}