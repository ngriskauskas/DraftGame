namespace Draft.Core.Entities
{
    public class GameTeam
    {
        public Game Game { get; private set; }
        public Team Team { get; private set; }
        public TeamSide TeamSide { get; private set; }
        public int TeamId { get; private set; }
        public int GameId { get; private set; }

        private GameTeam() { }
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