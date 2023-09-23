using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data_Access_Layer.Repositories.GenericRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected DbContext dbContext;
        protected readonly DbSet<TEntity> dbset;

        protected Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbset = dbContext.Set<TEntity>();
        }

        Task<TEntity?> IRepository<TEntity>.Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbset.FirstOrDefaultAsync(predicate);
        }

        void IRepository<TEntity>.Delete(TEntity entity)
        {
            dbset.Remove(entity);
        }

        public async Task Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await dbset.Where(predicate).ToListAsync();
            foreach (var entity in result)
            {
                dbset.Remove(entity);
            }
        }

        public async Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await dbset.Where(predicate).ToListAsync();
            return result;
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbset.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbset.ToListAsync();
        }

        public void Update(TEntity entity)
        {
            dbset.Update(entity);
        }
    }

}
