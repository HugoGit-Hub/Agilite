using Agilite.UnitOfWork;
using Agilite.UnitOfWork.Context;

namespace Agilite.Repositories.Repositories;

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
