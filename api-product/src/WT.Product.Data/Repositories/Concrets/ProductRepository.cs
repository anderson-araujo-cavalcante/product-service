using Microsoft.EntityFrameworkCore;
using WT.Product.Data.Context;
using WT.Product.Data.Repositories.Interfaces;

namespace WT.Product.Data.Repositories.Concrets
{
    public class ProductRepository : BaseRepository<Entities.Product>, IProductRepository
    {
        public ProductRepository(ProductContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Entities.Product>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().Include(_ => _.Category).ToListAsync();
        }

        public async Task<Entities.Product> GetByIdAsync(int id)
        {
            return await dbSet.AsNoTracking().Include(_ => _.Category).FirstOrDefaultAsync(e => e.Id == id);
        }

        #region IDisposable Members

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members
    }
}
