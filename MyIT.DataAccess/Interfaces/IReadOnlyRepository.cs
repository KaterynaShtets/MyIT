using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace MyIT.DataAccess.Interfaces
{
    public interface IReadOnlyRepository<TEntity>
    {
        Task<TEntity> GetAsync(
            Guid id,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includeProperties = null);

        Task<IEnumerable<TEntity>> GetAsync(
           Expression<Func<TEntity, bool>>? filter = null,
           Expression<Func<TEntity, object>>? sorter = null,
           bool sortDescending = false,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includeProperties = null);

        Task<IEnumerable<TEntity>> GetAsync(
           List<Expression<Func<TEntity, bool>>>? filter = null,
           Expression<Func<TEntity, object>>? sorter = null,
           bool sortDescending = false,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includeProperties = null);

        Task<IEnumerable<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includeProperties = null);

        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);

        Task<int> CountAsync(List<Expression<Func<TEntity, bool>>> filter);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
    }
}
