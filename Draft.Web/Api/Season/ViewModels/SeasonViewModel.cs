using System;

namespace Draft.Web.Api
{
    public class SeasonViewModel
    {
        public DateTime CurDate { get; set; }
        public PhaseViewModel CurPhase { get; set; }
        public StandingsViewModel Standings { get; set; }

    }
}