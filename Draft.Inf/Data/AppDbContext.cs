using System.Linq;
using System.Reflection;
using Draft.Core.Entities;
using Draft.Core.Interfaces;
using Draft.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Draft.Inf.Data
{

    public class AppDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Standings> Standings { get; set; }
        public DbSet<ArcTeam> ArcTeams { get; set; }
        private readonly IDomainEventDispatcher _dispatcher;

        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Player>()
            .HasOne(p => p.Team)
            .WithMany(t => t.Players);

            builder.Entity<GameTeam>()
            .HasKey(gt => new { gt.TeamId, gt.GameId });



            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();

            if (_dispatcher == null) return result;

            var entitiesWithEvents = ChangeTracker.Entries<Entity>()
                .Select(e => e.Entity)
                .Where(a => a.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                    _dispatcher.Dispatch(domainEvent);
            }
            return result;
        }
    }
}