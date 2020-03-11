using System;
using System.Collections.Generic;
using Classificados.Domain.Core.Events;

namespace Classificados.Infrastructure.EntityFramework.Repositories.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
