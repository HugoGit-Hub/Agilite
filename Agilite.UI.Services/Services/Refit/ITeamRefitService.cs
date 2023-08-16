using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface ITeamRefitService : IBaseRefitClient
{
    [Post(EndPointConstantes.CreateTeam)]
    public Task<TeamDto> Create(TeamDto team);

    [Put(EndPointConstantes.UpdateTeam)]
    public Task<TeamDto> Update(TeamDto entity);

    [Get(EndPointConstantes.AllTeams)]
    public Task<IEnumerable<TeamDto>> GetAll();

    [Get(EndPointConstantes.AllTeamsOfOneUser)]
    public Task<IEnumerable<TeamDto>> GetAllTeamsOfOneUser(int idUser);

    [Get(EndPointConstantes.Team)]
    public Task<TeamDto> Get(int id);

    [Delete(EndPointConstantes.DeleteTeam)]
    public Task<TeamDto> Delete(int id);
}