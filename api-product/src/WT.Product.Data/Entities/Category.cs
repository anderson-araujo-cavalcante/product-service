namespace WT.Product.Data.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
    }
}
