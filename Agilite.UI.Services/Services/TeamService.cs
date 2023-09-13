using Agilite.DataTransferObject;
using Agilite.UI.Models.Models;
using Agilite.UI.Services.Refit;
using AutoMapper;

namespace Agilite.UI.Services.Services;

public interface ITeamService
{
    public Task<TeamModel> Create(TeamModel entity);
    public Task<TeamModel> Get(int id);
    public Task<IEnumerable<TeamModel>> GetAllTeamsOfOneUser(int id);
    public Task<TeamModel> DeleteTeam(int id);
}

public class TeamService : ITeamService
{
    private const string ID_USER = "sub";

    private readonly ITeamRefit _refitService;
    private readonly IMapper _mapper;

    public TeamService(ITeamRefit refitService, IMapper mapper)
    {
        _refitService = refitService;
        _mapper = mapper;
    }

    public async Task<TeamModel> Create(TeamModel entity)
    {
        var team = new TeamDto
        {
            NameTeam = entity.NameTeam,
            NumberMembersTeam = entity.NumberMembersTeam,
            IdUser = int.Parse(TokenService.GetClaimValue(ID_USER))
        };

        var result = await _refitService.Create(team);

        return _mapper.Map<TeamModel>(result);
    }

    public async Task<TeamModel> Get(int id)
    {
        var result = await _refitService.Get(id);
        return _mapper.Map<TeamModel>(result);
    }

    public async Task<IEnumerable<TeamModel>> GetAllTeamsOfOneUser(int id)
    {
        var result = await _refitService.GetAllTeamsOfOneUser(id);
        return _mapper.Map<IEnumerable<TeamModel>>(result);
    }

    public async Task<TeamModel> DeleteTeam(int id)
    {
        var result = await _refitService.Delete(id);
        return _mapper.Map<TeamModel>(result);
    }
}