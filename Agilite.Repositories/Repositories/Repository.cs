using Agilite.UnitOfWork;
using Agilite.UnitOfWork.IRepositories;

namespace Agilite.Repositories.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly AgiliteContext _context;

    public Repository(AgiliteContext context)
    {
        _context = context;
    }

    public TEntity Create(TEntity entity)
    {
        return _context.Set<TEntity>().Add(entity).Entity;
    }

    public TEntity Update(TEntity entity)
    {
        return _context.Set<TEntity>().Update(entity).Entity;
    }

    public TEntity Delete(TEntity entity)
    {
        return _context.Set<TEntity>().Remove(entity).Entity;
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>();
    }

}