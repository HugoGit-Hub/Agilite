using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services.Refit;
using AutoMapper;

namespace Agilite.UI.Services.Services;

public interface IObjectiveService
{
    public Task<IEnumerable<ObjectiveModel>> GetAllObjectivesOfOneSprint(int id);
}

public class ObjectiveService : IObjectiveService
{
    private readonly IMapper _mapper;
    private readonly IObjectiveRefitService _objectiveRefitService;

    public ObjectiveService(IMapper mapper, IObjectiveRefitService objectiveRefitService)
    {
        _mapper = mapper;
        _objectiveRefitService = objectiveRefitService;
    }

    public async Task<IEnumerable<ObjectiveModel>> GetAllObjectivesOfOneSprint(int id)
    {
        var result = await _objectiveRefitService.GetAllOfOneSprint(id);

        return _mapper.Map<IEnumerable<ObjectiveModel>>(result);
    }
}