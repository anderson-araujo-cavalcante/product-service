using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WT.Product.Data.Context;
using WT.Product.Data.Entities;
using WT.Product.Data.Repositories.Interfaces;

namespace WT.Product.Data.Repositories.Concrets
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        protected ProductContext _context;
        protected DbSet<TEntity> dbSet;

        #region Ctor
        public BaseRepository(ProductContext dbContext)
        {
            _context = dbContext;
            dbSet = _context.Set<TEntity>();
        }
        #endregion       

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, TEntity entity)
        {
            dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
