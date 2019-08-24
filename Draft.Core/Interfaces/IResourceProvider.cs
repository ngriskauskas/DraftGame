using System;

namespace Draft.Core.Interfaces
{
    public interface IResourceProvider
    {
        int[][] GetGameSchedule();
        int[][] GetGameScores();
        DateTime[] GetGameDates();
    }
}