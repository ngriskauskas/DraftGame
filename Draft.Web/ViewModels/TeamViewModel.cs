namespace Draft.Web.ViewModels
{
    public class TeamViewModel
    {
        public string Name { get; set; }
        public string Division { get; set; }
        public int RecordWins { get; set; }
        public int RecordLosses { get; set; }
        public int RecordTies { get; set; }
        public int OffRating { get; set; }
        public int DefRating { get; set; }
        public PlayerViewModel[] Players { get; set; }

    }
}