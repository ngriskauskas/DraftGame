namespace Draft.Core.Entities
{
    public class GameTeam
    {
        public Game Game { get; }
        public Team Team { get; }
        public TeamSide TeamSide { get; }

        public GameTeam(Team team, TeamSide teamSide)
        {
            Team = team;
            TeamSide = teamSide;
        }
    }

    public enum TeamSide
    {
        Home,
        Away
    }
}