namespace Draft.Web.ViewModels
{
    public class PlayerViewModel
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public int Experience { get; set; }
        public string Position { get; set; }
        public string TeamName { get; set; }
        public bool IsStarter { get; set; }
        public bool IsInjured { get; set; }
    }
}