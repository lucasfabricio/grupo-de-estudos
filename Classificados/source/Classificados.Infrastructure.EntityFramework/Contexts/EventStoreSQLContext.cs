using Microsoft.EntityFrameworkCore;
using Classificados.Domain.Core.Events;
using Classificados.Infrastructure.EntityFramework.Mappings;

namespace Classificados.Infrastructure.EntityFramework.Contexts
{
    public class EventStoreSqlContext : DbContext
    {
        public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options) : base(options) { }

        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
