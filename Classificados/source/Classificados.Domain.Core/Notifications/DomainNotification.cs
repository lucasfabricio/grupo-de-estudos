using Classificados.Domain.Core.Events;
using System;

namespace Classificados.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public Guid DomainNotificattionId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificattionId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}
