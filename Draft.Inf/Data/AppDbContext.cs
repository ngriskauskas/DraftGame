using System.Linq;
using System.Reflection;
using Draft.Core.Interfaces;
using Draft.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Draft.Inf.Data
{

    public class AppDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();

            if (_dispatcher == null) return result;

            var entitiesWithEvents = ChangeTracker.Entries<Aggregate>()
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