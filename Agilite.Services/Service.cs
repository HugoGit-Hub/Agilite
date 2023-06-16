using Agilite.UnitOfWork;

namespace Agilite.Services;

public interface IService<TEntity>
{
    public TEntity Create(TEntity entity);

    public IEnumerable<TEntity> GetAll();

    public TEntity GetById(int id);

    public TEntity Delete(TEntity entity);

    public TEntity Update(TEntity entity);
}

public interface IService<TEntity, in TId> : IService<TEntity>
{
    TEntity? Get(TId id);
}

public class Service<TEntity> : IService<TEntity> where TEntity : class
{
    private readonly IUnitOfWork _unitOfWork;

    public Service(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public TEntity Create(TEntity entity)
    {
        var createdEntity = _unitOfWork.GetRepository<TEntity>().Create(entity);
        _unitOfWork.Save();
        return createdEntity;
    }

    public TEntity Delete(TEntity entity)
    {
        var deletedEntity = _unitOfWork.GetRepository<TEntity>().Delete(entity);
        _unitOfWork.Save();
        return deletedEntity;
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _unitOfWork.GetRepository<TEntity>().GetAll();
    }

    public TEntity GetById(int id)
    {
        var getGetById = _unitOfWork.GetRepositoryEntityById<TEntity, int>().Get(id);
        if (getGetById is null)
        {
            throw new ArgumentNullException($"L'entitée avec l'id : {id}, n'existe pas");
        }
        return getGetById;
    }

    public TEntity Update(TEntity entity)
    {
        var updateEntity = _unitOfWork.GetRepository<TEntity>().Update(entity);
        _unitOfWork.Save();
        return updateEntity;
    }
}
