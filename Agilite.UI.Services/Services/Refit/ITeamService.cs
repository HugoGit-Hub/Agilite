using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface ITeamService : IBaseRefitClient
{
    [Post(EndPointConstantes.CREATE_TEAM)]
    public TeamDto Create(TeamDto entity);

    [Put(EndPointConstantes.UPDATE_TEAM)]
    public TeamDto Update(TeamDto entity);

    [Get(EndPointConstantes.GET_ALL_TEAMS)]
    public Task<IEnumerable<TeamDto>> GetAll();

    [Get(EndPointConstantes.GET_TEAM)]
    public TeamDto Get(int id);

    [Delete(EndPointConstantes.DELETE_TEAM)]
    public TeamDto Delete(TeamDto entity);
}