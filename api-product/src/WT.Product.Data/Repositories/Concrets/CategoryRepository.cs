using WT.Product.Data.Context;
using WT.Product.Data.Repositories.Interfaces;

namespace WT.Product.Data.Repositories.Concrets
{
    public class CategoryRepository : BaseRepository<Entities.Category>, ICategoryRepository
    {
        public CategoryRepository(ProductContext dbContext) : base(dbContext)
        {
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
