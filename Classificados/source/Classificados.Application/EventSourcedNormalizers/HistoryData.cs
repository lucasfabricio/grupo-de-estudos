namespace Classificados.Application.EventSourcedNormalizers
{
    public abstract class HistoryData
    {
        public string Id { get; set; }
        public string Action { get; set; }
        public string Timestamp { get; set; }
        public string Who { get; set; }
    }
}
