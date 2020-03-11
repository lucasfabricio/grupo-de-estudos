using Classificados.Domain.Models;
using System;
using System.Collections.Generic;

namespace Classificados.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByName(string name);
        List<Category> GetChildrenCategories(Guid parentCategoryId);
    }
}
