using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface ITeamRefitService : IBaseRefitClient
{
    [Post(EndPointConstantes.CREATE_TEAM)]
    public Task<TeamDto> Create(TeamDto entity);

    [Put(EndPointConstantes.UPDATE_TEAM)]
    public Task<TeamDto> Update(TeamDto entity);

    [Get(EndPointConstantes.GET_ALL_TEAMS)]
    public Task<IEnumerable<TeamDto>> GetAll();

    [Get(EndPointConstantes.GET_TEAM)]
    public Task<TeamDto> Get(int id);

    [Delete(EndPointConstantes.DELETE_TEAM)]
    public Task<TeamDto> Delete(TeamDto entity);
}