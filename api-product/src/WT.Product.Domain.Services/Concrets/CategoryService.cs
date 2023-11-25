using WT.Product.Data.Context;
using WT.Product.Data.Repositories.Concrets;
using WT.Product.Domain.Services.Interfaces;

namespace WT.Product.Domain.Services.Concrets
{
    public class CategoryService : BaseRepository<Data.Entities.Category>, ICategoryService
    {
        public CategoryService(ProductContext dbContext) : base(dbContext)
        {
        }
    }
}
