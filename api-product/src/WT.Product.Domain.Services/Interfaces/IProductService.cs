using WT.Product.Data.Repositories.Interfaces;

namespace WT.Product.Domain.Services.Interfaces
{
    public interface IProductService : IBaseRepository<Data.Entities.Product>
    {
        Task<IEnumerable<Data.Entities.Product>> GetAllAsync();
        Task<Data.Entities.Product> GetByIdAsync(int id);
    }
}
