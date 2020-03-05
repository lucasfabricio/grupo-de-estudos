namespace Classificados.Domain.Entities
{
    public class Category
    {
        public string Name { get; set; }
        public int ParentCategory_Id { get; set; }
        public Category ParentCategory { get; set; }
    }
}