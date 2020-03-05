using System;

namespace Classificados.Domain.Entities
{
    public class Advertisement : BaseEntity
    {
        public string Title { get; set; }
        public DateTime? Published { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int Category_Id { get; set; }
    }
}
