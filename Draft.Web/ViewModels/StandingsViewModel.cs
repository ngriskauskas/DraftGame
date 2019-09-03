namespace Draft.Web.ViewModels
{
    public class StandingsViewModel
    {
        public string ChampionName { get; set; }
        public string WestChampName { get; set; }
        public string EastChampName { get; set; }
        public TeamRecordViewModel[] EastStandings { get; set; }
        public TeamRecordViewModel[] WestStandings { get; set; }
    }
}