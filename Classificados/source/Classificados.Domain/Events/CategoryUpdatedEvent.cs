﻿using Classificados.Domain.Core.Events;
using System;

namespace Classificados.Domain.Events
{
    public class CategoryUpdatedEvent : Event
    {
        public CategoryUpdatedEvent(Guid id, string name, Guid? parentCategoryId = null)
        {
            Id = id;
            Name = name;
            ParentCategoryId = parentCategoryId;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid? ParentCategoryId { get; private set; }
    }
}
