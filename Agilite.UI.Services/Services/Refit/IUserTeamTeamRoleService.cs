using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface IUserTeamTeamRoleService : IBaseRefitClient
{

    [Post(EndPointConstantes.CREATE_USER_TEAM_TEAM_ROLE)]
    public UserTeamTeamRoleDto Create(UserTeamTeamRoleDto entity);

    [Put(EndPointConstantes.UPDATE_USER_TEAM_TEAM_ROLE)]
    public UserTeamTeamRoleDto Update(UserTeamTeamRoleDto entity);

    [Get(EndPointConstantes.GET_ALL_USER_TEAM_TEAM_ROLES)]
    public Task<IEnumerable<UserTeamTeamRoleDto>> GetAll();

    [Get(EndPointConstantes.GET_USER_TEAM_TEAM_ROLE)]
    public UserTeamTeamRoleDto Get(int id);

    [Delete(EndPointConstantes.DELETE_USER_TEAM_TEAM_ROLE)]
    public UserTeamTeamRoleDto Delete(UserTeamTeamRoleDto entity);
}