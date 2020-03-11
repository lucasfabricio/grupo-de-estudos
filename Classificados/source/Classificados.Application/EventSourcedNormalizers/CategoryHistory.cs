using Classificados.Domain.Core.Events;
using Classificados.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Classificados.Application.EventSourcedNormalizers
{
    public class CategoryHistory
    {
        public static IList<CategoryHistoryData> HistoryData { get; set; }

        public static IList<CategoryHistoryData> ToJavaScriptCustomerHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<CategoryHistoryData>();
            CustomerHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<CategoryHistoryData>();
            var last = new CategoryHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new CategoryHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Name = string.IsNullOrWhiteSpace(change.Name) || change.Name == last.Name
                        ? ""
                        : change.Name,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void CustomerHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonSerializer.Deserialize<CategoryHistoryData>(e.Data);
                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case nameof(CategoryCreatedEvent):
                        historyData.Action = "Created";
                        historyData.Who = e.User;
                        break;
                    //case nameof(CategoryUpdatedEvent):
                    //    historyData.Action = "Updated";
                    //    historyData.Who = e.User;
                    //    break;
                    //case nameof(CategoryRemovedEvent):
                    //    historyData.Action = "Removed";
                    //    historyData.Who = e.User;
                    //    break;
                }
                HistoryData.Add(historyData);
            }
        }
    }
}
