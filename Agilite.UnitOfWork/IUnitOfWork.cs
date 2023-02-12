namespace Agilite.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    IRepository<TEntity, TId> GetRepositoryEntityById<TEntity, TId>() where TEntity : class;
    void Save();
}

