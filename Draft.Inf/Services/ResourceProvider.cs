using System;
using System.Linq;
using Draft.Core.Interfaces;
using Draft.Inf.Utils;

namespace Draft.Inf.Services
{
    public class ResourceProvider : IResourceProvider
    {
        private readonly string gameScheduleData = "..\\Draft.Inf\\Data\\SeedData\\schedule.txt";
        private readonly string gameDateData = "..\\Draft.Inf\\Data\\SeedData\\gameDates.json";
        private readonly string gameScoreData = "..\\Draft.Inf\\Data\\SeedData\\scores.txt";

        private static DateTime[] GameDates;
        private static int[][] GameSchedule;
        private static int[][] GameScores;
        public DateTime[] GetGameDates()
        {
            if (GameDates == null)
                GameDates = FileReader.GetCollection<DateTime>(gameDateData).ToArray();

            return GameDates;
        }

        public int[][] GetGameSchedule()
        {
            if (GameSchedule == null)
                GameSchedule = FileReader.GetTable(gameScheduleData);
            return GameSchedule;
        }

        public int[][] GetGameScores()
        {
            if (GameScores == null)
                GameScores = FileReader.GetTable(gameScoreData);
            return GameScores;
        }
    }
}