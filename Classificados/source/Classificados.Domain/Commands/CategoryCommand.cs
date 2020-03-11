using Classificados.Domain.Core.Commands;
using System;

namespace Classificados.Domain.Commands
{
    public abstract class CategoryCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Guid? ParentCategoryId { get; protected set; }
    }
}
