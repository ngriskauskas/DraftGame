namespace Draft.Web.ViewModels
{
    public abstract class BasePlayerViewModel
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public int Experience { get; set; }
        public string Position { get; set; }
        public bool IsInjured { get; set; }

    }
}