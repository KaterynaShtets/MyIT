namespace MyIT.DataAccess.Interfaces
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
    {
        Guid Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(Guid id);
    }
}
