using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface ITeamRoleService : IBaseRefitClient
{
    [Post(EndPointConstantes.CREATE_TEAM_ROLE)]
    public TeamRoleDto Create(TeamRoleDto entity);

    [Put(EndPointConstantes.UPDATE_TEAM_ROLE)]
    public TeamRoleDto Update(TeamRoleDto entity);

    [Get(EndPointConstantes.GET_ALL_TEAM_ROLES)]
    public Task<IEnumerable<TeamRoleDto>> GetAll();

    [Get(EndPointConstantes.GET_TEAM_ROLE)]
    public TeamRoleDto Get(int id);

    [Delete(EndPointConstantes.DELETE_TEAM_ROLE)]
    public TeamRoleDto Delete(TeamRoleDto entity);
}