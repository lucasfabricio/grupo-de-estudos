using Microsoft.EntityFrameworkCore;
using Classificados.Domain.Core.Events;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Classificados.Infrastructure.EntityFramework.Mappings
{
    public class StoredEventMap : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.Property(c => c.Timestamp)
                .HasColumnName("CreationDate");

            builder.Property(c => c.MessageType)
                .HasColumnName("Action")
                .HasColumnType("varchar(100)");
        }
    }
}
