using System.Linq.Expressions;

namespace Data_Access_Layer.Repositories.GenericRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> Find(Expression<Func<TEntity, bool>> predicate);

        void Delete(TEntity entity);

        Task AddAsync(TEntity entity);

        Task Delete(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAll();

        void Update(TEntity entity);
    }
}
