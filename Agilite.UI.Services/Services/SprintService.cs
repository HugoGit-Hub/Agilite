using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services.Refit;
using AutoMapper;

namespace Agilite.UI.Services.Services;

public interface ISprintService
{
    public Task<IEnumerable<SprintModel>> GetAllSprintsOfOneProject(int id);
}

public class SprintService : ISprintService
{
    private readonly IMapper _mapper;
    private readonly ISprintRefitService _refitService;

    public SprintService(IMapper mapper, ISprintRefitService refitService)
    {
        _mapper = mapper;
        _refitService = refitService;
    }

    public async Task<IEnumerable<SprintModel>> GetAllSprintsOfOneProject(int id)
    {
        var sprints = await _refitService.GetAllSprintsOfOneProject(id);
        return _mapper.Map<IEnumerable<SprintModel>>(sprints);
    }
}