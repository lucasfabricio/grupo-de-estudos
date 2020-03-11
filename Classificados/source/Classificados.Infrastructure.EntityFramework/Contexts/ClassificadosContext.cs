using Classificados.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Classificados.Infrastructure.EntityFramework.Mappings;

namespace Classificados.Infrastructure.EntityFramework.Contexts
{
    public class ClassificadosContext : DbContext
    {
        public ClassificadosContext(DbContextOptions<ClassificadosContext> options) : base(options) { }

        #region DB Sets
        public DbSet<Category> Categories { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
