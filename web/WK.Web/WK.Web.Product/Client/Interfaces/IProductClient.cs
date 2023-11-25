namespace WK.Web.Product.Client.Interfaces
{
    public interface IProductClient
    {
        Task AddProductAsync(Models.Product product);
        Task EditProductAsync(Models.Product product);
        Task DeleteProductAsync(int id);
        Task<Models.Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Models.Product>> GetAllProductsAsync();

        Task AddCategoryAsync(Models.Category category);
        Task EditCategoryAsync(Models.Category category);
        Task DeleteCategoryAsync(int id);
        Task<Models.Category> GetCategoryByIdAsync(int id);
        Task<IEnumerable<Models.Category>> GetAllCategoriesAsync();

    }
}
