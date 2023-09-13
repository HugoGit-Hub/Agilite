using Agilite.DataTransferObject;
using Agilite.UI.Models.Models;
using Agilite.UI.Services.Refit;
using AutoMapper;

namespace Agilite.UI.Services.Services;

public interface IProjectService
{
    public Task<ProjectModel> Create(ProjectModel model);
    public Task<IEnumerable<ProjectModel>> GetAllProjectsOfOneTeam(int idTeam);
}

public class ProjectService : IProjectService
{
    private readonly IMapper _mapper;
    private readonly IProjectRefit _refitService;

    public ProjectService(IMapper mapper, IProjectRefit refitService)
    {
        _mapper = mapper;
        _refitService = refitService;
    }

    public async Task<ProjectModel> Create(ProjectModel model)
    {
        var dto = _mapper.Map<ProjectDto>(model);
        var result = await _refitService.Create(dto);
        return _mapper.Map<ProjectModel>(result);
    }

    public async Task<IEnumerable<ProjectModel>> GetAllProjectsOfOneTeam(int idTeam)
    {
        var result = await _refitService.GetAllProjectsOfOneTeam(idTeam);
        return _mapper.Map<IEnumerable<ProjectModel>>(result);
    }
}