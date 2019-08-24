using System;
using System.Collections.Generic;
using System.Linq;
using Draft.Core.Events;
using Draft.Core.SharedKernel;

namespace Draft.Core.Entities
{
    public class Game : Aggregate
    {
        public DateTime Date { get; private set; }
        public ICollection<GameTeam> GameTeams { get; private set; } = new List<GameTeam>();
        public int HomeScore { get; private set; } = 0;
        public int AwayScore { get; private set; } = 0;
        public bool IsCompleted { get; private set; } = false;


        public Team HomeTeam => GameTeams.Single(t => t.TeamSide == TeamSide.Home).Team;
        public Team AwayTeam => GameTeams.Single(t => t.TeamSide == TeamSide.Away).Team;
        public bool IsTie => IsCompleted ? HomeScore == AwayScore : false;
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
        public Game(DateTime date, GameTeam homeTeam, GameTeam awayTeam)
        {
            Date = date;
            GameTeams.Add(homeTeam);
            GameTeams.Add(awayTeam);
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