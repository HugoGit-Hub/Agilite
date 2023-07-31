using Agilite.Entities.Entities;
using Agilite.Repositories.Repositories;

namespace Agilite.Services;

public interface ISprintService
{
    public Task<IEnumerable<Sprint>> GetAllSprintsOfOneProject(int projectId, CancellationToken cancellationToken);
}

public class SprintService : ISprintService
{
    private readonly ISprintRepository _repository;

    public SprintService(ISprintRepository repository)
        => _repository = repository;

    public async Task<IEnumerable<Sprint>> GetAllSprintsOfOneProject(int projectId, CancellationToken cancellationToken)
        => await _repository.GetAllSprintsOfOneProject(projectId, cancellationToken);
}