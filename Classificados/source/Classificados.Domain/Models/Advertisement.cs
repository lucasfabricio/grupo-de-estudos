using Classificados.Domain.Core.Models;
using System;

namespace Classificados.Domain.Models
{
    public class Advertisement : Entity
    {
        public Advertisement(Guid id, string title, string description, Guid categoryId)
        {
            Id = id;
            Title = title;
            Description = description;
            CategoryId = categoryId;
        }

        public string Title { get; set; }
        public DateTime? Published { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
