using Agilite.Entities.Entities;
using Agilite.Repositories.Repositories;

namespace Agilite.Services;

public interface ISprintService
{
    public Task<Sprint> Create(Sprint sprint, CancellationToken cancellationToken);
    public Task<IEnumerable<Sprint>> GetAllSprintsOfOneProject(int projectId, CancellationToken cancellationToken);
}

public class SprintService : ISprintService
{
    private readonly ISprintRepository _repository;

    public SprintService(ISprintRepository repository)
        => _repository = repository;

    public async Task<Sprint> Create(Sprint sprint, CancellationToken cancellationToken)
    {
        var lastSprint = await GetLastSprintNumber(sprint.FkProject, cancellationToken);
        sprint.NumberSprint = lastSprint is null ? 1 : lastSprint.Value + 1;
        sprint.StartDateSprint = DateTime.Now;
        sprint.EndDateSprint = DateTime.Now.AddDays(14);

        return await _repository.Create(sprint, cancellationToken);
    }

    public async Task<IEnumerable<Sprint>> GetAllSprintsOfOneProject(int projectId, CancellationToken cancellationToken)
        => await _repository.GetAllSprintsOfOneProject(projectId, cancellationToken);

    private async Task<int?> GetLastSprintNumber(int idProject, CancellationToken cancellationToken)
        => await _repository.GetLastSprintNumber(idProject, cancellationToken);
}