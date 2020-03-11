namespace Classificados.Application.EventSourcedNormalizers
{
    public class CategoryHistoryData : HistoryData
    {
        public string Name { get; set; }
        public string ParentCategoryId { get; set; }
    }
}
