using Agilite.UnitOfWork;

namespace Agilite.Repositories;

public class RepositoryEtityById<TEntity, TId> : Repository<TEntity>, IRepository<TEntity, TId> where TEntity : class
{
    public RepositoryEtityById(AgiliteContext context)
        : base(context)
    {
    }

    public TEntity? Get(TId id)
    {
        return _context.Set<TEntity>().Find(id);
    }
}
