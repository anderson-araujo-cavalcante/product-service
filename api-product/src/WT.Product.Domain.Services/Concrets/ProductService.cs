using WT.Product.Data.Context;
using WT.Product.Data.Repositories.Concrets;
using WT.Product.Data.Repositories.Interfaces;
using WT.Product.Domain.Services.Interfaces;

namespace WT.Product.Domain.Services.Concrets
{
    public class ProductService : BaseRepository<Data.Entities.Product>, IProductService
    {
        readonly IProductRepository _productRepository;
        public ProductService(ProductContext dbContext,
                                   IProductRepository productRepository) : base(dbContext)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Data.Entities.Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Data.Entities.Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
    }
}
