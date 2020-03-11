using Classificados.Domain.Core.Models;
using System;

namespace Classificados.Domain.Models
{
    public class Category : Entity
    {
        public Category(Guid id, string name, Guid? parentCategoryId = null)
        {
            Id = id;
            Name = name;
            ParentCategoryId = parentCategoryId;
        }

        protected Category() { }

        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
    }
}