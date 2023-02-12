namespace Agilite.UnitOfWork;

public interface IService<Tentity>
{
    public Tentity Create(Tentity entity);

    public IEnumerable<Tentity> GetAll();

    public Tentity GetById(int id);

    public Tentity Delete(Tentity entity);

    public Tentity Update(Tentity entity);
}

public interface IService<TEntity, in TId> : IService<TEntity>
{
    TEntity? Get(TId id);
}