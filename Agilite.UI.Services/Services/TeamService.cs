using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services.Refit;
using AutoMapper;

namespace Agilite.UI.Services.Services;

public interface ITeamService
{
    public Task<IEnumerable<TeamModel>> GetAllTeamsOfOneUser(int id);
}

public class TeamService : ITeamService
{
    private readonly ITeamRefitService _refitService;
    private readonly IMapper _mapper;

    public TeamService(ITeamRefitService refitService, IMapper mapper)
    {
        _refitService = refitService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TeamModel>> GetAllTeamsOfOneUser(int id)
    {
        var result = await _refitService.GetAllTeamsOfOneUser(id);
        return _mapper.Map<IEnumerable<TeamModel>>(result);
    }
}