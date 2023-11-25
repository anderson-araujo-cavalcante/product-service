namespace WK.Web.Product.Models
{
    public class Product
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public Product()
        {
                Category = new Category();
        }

        public string CategoryDescription => Category.Name;
    }
}
