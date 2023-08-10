using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services.Refit;
using AutoMapper;

namespace Agilite.UI.Services.Services;

public interface IProjectService
{
    public Task<ProjectModel> Create(string name);
    public Task<IEnumerable<ProjectModel>> GetAllProjectsOfOneTeam(int idTeam);
}

public class ProjectService : IProjectService
{
    private readonly IMapper _mapper;
    private readonly IProjectRefitService _refitService;

    public ProjectService(IMapper mapper, IProjectRefitService refitService)
    {
        _mapper = mapper;
        _refitService = refitService;
    }

    public async Task<ProjectModel> Create(string name)
    {
        var result = await _refitService.Create(name);
        return _mapper.Map<ProjectModel>(result);
    }

    public async Task<IEnumerable<ProjectModel>> GetAllProjectsOfOneTeam(int idTeam)
    {
        var result = await _refitService.GetAllProjectsOfOneTeam(idTeam);
        return _mapper.Map<IEnumerable<ProjectModel>>(result);
    }
}