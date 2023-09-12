using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using Agilite.UI.Services.Refit;
using AutoMapper;

namespace Agilite.UI.Services.Services;

public interface ISprintService
{
    public Task<SprintModel> Create(SprintModel sprint);
    public Task<IEnumerable<SprintModel>> GetAllSprintsOfOneProject(int id);
    public Task<SprintModel> Get(int id);
}

public class SprintService : ISprintService
{
    private readonly IMapper _mapper;
    private readonly ISprintRefit _refitService;

    public SprintService(IMapper mapper, ISprintRefit refitService)
    {
        _mapper = mapper;
        _refitService = refitService;
    }

    public async Task<SprintModel> Create(SprintModel sprint)
    {
        var dto = _mapper.Map<SprintDto>(sprint);
        var result = await _refitService.Create(dto);

        return _mapper.Map<SprintModel>(result);
    }

    public async Task<IEnumerable<SprintModel>> GetAllSprintsOfOneProject(int id)
    {
        var sprints = await _refitService.GetAllSprintsOfOneProject(id);
        return _mapper.Map<IEnumerable<SprintModel>>(sprints);
    }

    public async Task<SprintModel> Get(int id)
    {
        var sprint = await _refitService.Get(id);
        return _mapper.Map<SprintModel>(sprint);
    }
}