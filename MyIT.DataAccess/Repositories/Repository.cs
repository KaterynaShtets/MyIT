using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyIT.Contracts;
using MyIT.DataAccess.Interfaces;

namespace MyIT.DataAccess.Repositories
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseContract
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        private DbSet<TEntity> DbSet => _context.Set<TEntity>();

        private IQueryable<TEntity> NoTrackingDbSet => _context.Set<TEntity>().AsNoTracking();

        public Task<TEntity> GetAsync(
            Guid id,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null)
        {
            return includeProperties != null
                ? includeProperties(NoTrackingDbSet).FirstOrDefaultAsync(x => x.Id == id)
                : NoTrackingDbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Expression<Func<TEntity, object>> sorter = null,
            bool sortDescending = false,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null)
        {
            return await GetAsync(
                filter == null ? null : new List<Expression<Func<TEntity, bool>>>() { filter },
                sorter,
                sortDescending,
                includeProperties);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(
            List<Expression<Func<TEntity, bool>>> filter = null,
            Expression<Func<TEntity, object>> sorter = null,
            bool sortDescending = false,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null)
        {
            var query = _context.Set<TEntity>().AsNoTracking();

            var resultSet = AssignPredicates(query, filter);

            if (sorter != null)
            {
                resultSet = sortDescending
                    ? resultSet.OrderByDescending(sorter)
                    : resultSet.OrderBy(sorter);
            }

            if (includeProperties != null)
            {
                resultSet = includeProperties(resultSet);
            }

            return await resultSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null)
        {
            return includeProperties != null
                ? await includeProperties(NoTrackingDbSet).ToListAsync()
                : await NoTrackingDbSet.ToListAsync();
        }

        public Task<int> CountAsync() => NoTrackingDbSet.CountAsync();

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> filter) => NoTrackingDbSet.CountAsync(filter);

        public Task<int> CountAsync(List<Expression<Func<TEntity, bool>>> filter) => AssignPredicates(NoTrackingDbSet, filter).CountAsync();

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter) => NoTrackingDbSet.AnyAsync(filter);

        public Guid Create(TEntity entity) => DbSet.Add(entity).Entity.Id;

        public void Update(TEntity entity) => _context.Entry(DbSet.Find(entity.Id)).CurrentValues.SetValues(entity);

        public void Delete(TEntity entity) => Delete(entity.Id);

        public void Delete(Guid id)
        {
            var existingEntity = DbSet.Find(id);

            if (existingEntity == null)
            {
                return;
            }

            DbSet.Remove(existingEntity);
        }

        private IQueryable<TEntity> AssignPredicates(
            IQueryable<TEntity> query,
            IList<Expression<Func<TEntity, bool>>> predicates)
        {
            return predicates == null ? 
                query : 
                predicates.Aggregate(query, (current, predicate) => current.Where(predicate));
        }
    }
}