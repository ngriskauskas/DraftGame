namespace Draft.Web.ViewModels
{
    public class TeamViewModel : BaseTeamViewModel
    {
        public RecordViewModel Record { get; set; }
        public int OffRating { get; set; }
        public int DefRating { get; set; }
        public TeamPlayerViewModel[] Players { get; set; }
    }
}