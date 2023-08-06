using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services.Refit;
using AutoMapper;

namespace Agilite.UI.Services.Services;

public interface ITeamService
{
    public Task<TeamModel> Create(TeamModel entity);
    public Task<IEnumerable<TeamModel>> GetAllTeamsOfOneUser(int id);
}

public class TeamService : ITeamService
{
    private const string ID_USER = "sub";

    private readonly ITeamRefitService _refitService;
    private readonly IMapper _mapper;

    public TeamService(ITeamRefitService refitService, IMapper mapper)
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

    public async Task<IEnumerable<TeamModel>> GetAllTeamsOfOneUser(int id)
    {
        var result = await _refitService.GetAllTeamsOfOneUser(id);
        return _mapper.Map<IEnumerable<TeamModel>>(result);
    }
}