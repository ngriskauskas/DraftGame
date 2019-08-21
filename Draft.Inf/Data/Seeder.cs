using System;
using System.Collections.Generic;
using System.Linq;
using Draft.Core.Entities;
using Draft.Inf.Utils;

namespace Draft.Inf.Data
{
    public static class Seeder
    {
        private readonly static string teamData = "..\\Draft.Inf\\Data\\SeedData\\teams.json";
        public static void InitLeague(this AppDbContext db)
        {
            using (db)
            {
                DeleteOldRecords(db);
                SeedTeams(db);
                AddInitialSeason(db);
                Add5Seasons(db);
            }
        }

        private static void DeleteOldRecords(AppDbContext db)
        {
            db.RemoveAll(db.Players);
            db.RemoveAll(db.ArcTeams);
            db.RemoveAll(db.Teams);
            db.RemoveAll(db.Games);
            db.RemoveAll(db.Seasons);
            db.RemoveAll(db.Standings);
        }
        private static void SeedTeams(AppDbContext db)
        {
            var teams = FileReader.GetCollection<Team>(teamData);
            db.AddRange(teams);
            db.SaveChanges();
        }
        private static void AddInitialSeason(AppDbContext db)
        {
            var teams = db.Teams.ToList();
            teams.ForEach(t => t.UpdateStarters());

            var arcTeams = new List<ArcTeam>(
                teams.Select(t => new ArcTeam(t))
            );
            db.ArcTeams.AddRange(arcTeams);

            var season = new Season
            (
                new Standings(arcTeams),
                new DateTime(1949, 1, 1),
                false,
                true
            );
            db.Seasons.Add(season);

            db.SaveChanges();
        }

        private static void Add5Seasons(AppDbContext db)
        {
            for (int i = 0; i < 5; i++)
                db.Seasons.Add(
                    new Season(
                        new Standings(new List<ArcTeam>()),
                        new DateTime(1950 + i, 1, 1),
                        false,
                        false));

            db.SaveChanges();
        }
    }
}
