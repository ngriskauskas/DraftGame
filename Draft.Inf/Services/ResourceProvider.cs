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
        public DateTime[] GetGameDates()
        {
            return FileReader.GetCollection<DateTime>(gameDateData).ToArray();
        }

        public int[][] GetGameSchedule()
        {
            return FileReader.GetTable(gameScheduleData);
        }
    }
}