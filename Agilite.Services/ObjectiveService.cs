using Agilite.Entities.Entities;
using Agilite.Repositories.Repositories;

namespace Agilite.Services;

public interface IObjectiveService
{
    public Task<IEnumerable<Objective>> GetAllObjectivesOfOneSprint(int id);
}

public class ObjectiveService : IObjectiveService
{
    private readonly IObjectiveRepository _objectiveRepository;

    public ObjectiveService(IObjectiveRepository objectiveRepository)
        => _objectiveRepository = objectiveRepository;

    public async Task<IEnumerable<Objective>> GetAllObjectivesOfOneSprint(int id)
        => await _objectiveRepository.GetAllObjectivesOfOneSprint(id);
}