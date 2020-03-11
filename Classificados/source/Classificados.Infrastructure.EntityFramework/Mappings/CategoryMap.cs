using Classificados.Domain.Configs;
using Classificados.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Classificados.Infrastructure.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("Id");

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(CategoryConfig.NAME_MAX_LENGTH)
                .IsRequired();

            builder.Property(p => p.ParentCategoryId)
                .HasColumnName("ParentCategoryId");
        }
    }
}
