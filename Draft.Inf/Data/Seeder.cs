using System;
using System.Collections.Generic;
using System.Linq;
using Draft.Core.Entities;
using Draft.Inf.Utils;
using Microsoft.EntityFrameworkCore;

namespace Draft.Inf.Data
{
    public static class Seeder
    {
        private readonly static string teamData = "..\\Draft.Inf\\Data\\SeedData\\teams.json";
        private readonly static string phaseData = "..\\Draft.Inf\\Data\\SeedData\\phases.json";
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
            db.RemoveAll<Player>();
            db.RemoveAll<ArcTeam>();
            db.RemoveAll<Team>();
            db.RemoveAll<Record>();
            db.RemoveAll<Game>();
            db.RemoveAll<Phase>();
            db.RemoveAll<Season>();
            db.RemoveAll<Standings>();
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
                FileReader.GetCollection<Phase>(phaseData),
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
                        FileReader.GetCollection<Phase>(phaseData),
                        false,
                        false));

            db.SaveChanges();
        }
    }
}
