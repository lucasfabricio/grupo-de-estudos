using System;

namespace Classificados.Domain.Entities
{
    public abstract class BaseEntity
    {
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
