using Agilite.Repositories.Repositories;
using Agilite.UnitOfWork;
using Agilite.UnitOfWork.Context;
using System.Security.Cryptography;

namespace Agilite.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AgiliteContext _context;

    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(AgiliteContext context)
    {
        _context = context;
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        if (_repositories.ContainsValue(typeof(TEntity)))
        {
            return (IRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        var repository = new Repository<TEntity>(_context);
        _repositories.Add(typeof(TEntity), repository);

        return repository;
    }

    public IRepository<TEntity, TId> GetRepositoryEntityById<TEntity, TId>() where TEntity : class
    {
        if (_repositories.ContainsValue(typeof(TEntity)))
        {
            return (IRepository<TEntity, TId>)_repositories[typeof(TEntity)];
        }
        
        var reposiotry = new RepositoryEtityById<TEntity, TId>(_context);
        _repositories.Add(typeof(TEntity), reposiotry);

        return reposiotry;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
