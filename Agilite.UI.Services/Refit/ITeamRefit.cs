using Agilite.DataTransferObject;
using Refit;

namespace Agilite.UI.Services.Refit;

public interface ITeamRefit : IBaseRefitClient
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