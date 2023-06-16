using Agilite.Repositories.Repositories;
using Agilite.UnitOfWork;
using Agilite.UnitOfWork.IRepositories;

namespace Agilite.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AgiliteContext _context;

    public UnitOfWork(AgiliteContext context)
    {
        _context = context;
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        return new Repository<TEntity>(_context);
    }

    public IRepository<TEntity, TId> GetRepositoryEntityById<TEntity, TId>() where TEntity : class
    {
        return new RepositoryEtityById<TEntity, TId>(_context);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
