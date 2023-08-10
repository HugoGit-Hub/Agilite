using Agilite.Entities.Entities;
using Agilite.Repositories.Repositories;

namespace Agilite.Services;

public interface IProjectTypeService
{
    public Task<IEnumerable<ProjectType>> GetAllProjectType(CancellationToken cancellationToken);
}

public class ProjectTypeService : IProjectTypeService
{
    private readonly IProjectTypeRepository _repository;

    public ProjectTypeService(IProjectTypeRepository repository)
        => _repository = repository;

    public async Task<IEnumerable<ProjectType>> GetAllProjectType(CancellationToken cancellationToken)
        => await _repository.GetAllProjectType(cancellationToken);
}