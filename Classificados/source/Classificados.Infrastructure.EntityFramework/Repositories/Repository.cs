using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Classificados.Domain.Interfaces;
using Classificados.Infrastructure.EntityFramework.Contexts;

namespace Classificados.Infrastructure.EntityFramework.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ClassificadosContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ClassificadosContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
