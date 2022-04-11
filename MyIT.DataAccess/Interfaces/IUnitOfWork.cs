using MyIT.Contracts;

namespace MyIT.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseContract;

        Task SaveChangesAsync();
    }
}
