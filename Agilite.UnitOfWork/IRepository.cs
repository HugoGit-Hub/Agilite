namespace Agilite.UnitOfWork;

public interface IRepository<TEntity>
    where TEntity : class
{
    TEntity Create(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
    IEnumerable<TEntity> GetAll();
}

public interface IRepository<TEntity, in TId> : IRepository<TEntity>
    where TEntity : class
{
    TEntity? Get(TId id);
}
