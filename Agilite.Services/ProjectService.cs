using Agilite.Entities;
using Agilite.Repositories.Repositories;

namespace Agilite.Services;

public interface IProjectService
{
    public Task<IEnumerable<Project>> GetAllProjectsOfOneTeam(int idTeam, CancellationToken cancellationToken);
}

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;

    public ProjectService(IProjectRepository repository)
        => _repository = repository;

    public async Task<IEnumerable<Project>> GetAllProjectsOfOneTeam(int idTeam, CancellationToken cancellationToken)
        => await _repository.GetAllProjectsOfOneTeam(idTeam, cancellationToken);
}