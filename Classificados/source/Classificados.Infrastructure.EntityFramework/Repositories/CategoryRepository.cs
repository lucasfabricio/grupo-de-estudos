using System;
using System.Linq;
using System.Collections.Generic;
using Classificados.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Classificados.Domain.Interfaces;
using Classificados.Infrastructure.EntityFramework.Contexts;

namespace Classificados.Infrastructure.EntityFramework.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ClassificadosContext context) : base(context) { }

        public Category GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Name == name);
        }

        public List<Category> GetChildrenCategories(Guid parentCategoryId)
        {
            return DbSet.AsNoTracking().Where(c => c.ParentCategoryId == parentCategoryId).ToList();
        }
    }
}
