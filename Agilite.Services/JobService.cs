using Agilite.Entities.Entities;
using Agilite.Repositories.Repositories;

namespace Agilite.Services;

public interface IJobService
{
    public Task<IEnumerable<Job>> GetAllJobsOfOneObjective(int id, CancellationToken cancellationToken);
}

public class JobService : IJobService
{
    private readonly IJobRepository _repository;

    public JobService(IJobRepository repository)
        => _repository = repository;

    public async Task<IEnumerable<Job>> GetAllJobsOfOneObjective(int id, CancellationToken cancellationToken) 
        => await _repository.GetAllJobsOfOneObjective(id, cancellationToken);
}