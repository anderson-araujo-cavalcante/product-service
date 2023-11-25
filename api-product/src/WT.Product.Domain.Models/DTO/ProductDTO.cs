namespace WT.Product.Domain.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        //public CategoryDTO Category { get; set; }
        public int CategoryId { get; set; }
    }
}
