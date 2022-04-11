using Microsoft.EntityFrameworkCore;
using MyIT.Contracts;
using MyIT.DataAccess.Interfaces;
using MyIT.DataAccess.Repositories;

namespace MyIT.DataAccess.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly IDictionary<Type, object> _repositoryStorage;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _repositoryStorage = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseContract
        {
            if (_repositoryStorage.ContainsKey(typeof(TEntity)))
            {
                return _repositoryStorage[typeof(TEntity)] as IRepository<TEntity>;
            }

            var repository = new Repository<TEntity>(_context);
            _repositoryStorage.Add(typeof(TEntity), repository);

            return repository;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}