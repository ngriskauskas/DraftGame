namespace Draft.Web.ViewModels
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Division { get; set; }
        public RecordViewModel Record { get; set; }
        public int OffRating { get; set; }
        public int DefRating { get; set; }
        public PlayerViewModel[] Players { get; set; }

    }
}