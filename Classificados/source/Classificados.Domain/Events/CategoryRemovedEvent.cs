using Classificados.Domain.Core.Events;
using System;

namespace Classificados.Domain.Events
{
    public class CategoryRemovedEvent : Event
    {
        public CategoryRemovedEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
