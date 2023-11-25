namespace WT.Product.Data.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Entities.Product>, IDisposable
    {
        Task<IEnumerable<Entities.Product>> GetAllAsync();
        Task<Entities.Product> GetByIdAsync(int id);
    }
}
