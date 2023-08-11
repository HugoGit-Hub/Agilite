using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface IProjectRefitService : IBaseRefitClient
{
    [Post(EndPointConstantes.CREATE_PROJECT)]
    public Task<ProjectDto> Create(ProjectDto projectDto);

    [Put(EndPointConstantes.UPDATE_PROJECT)]
    public Task<ProjectDto> Update(ProjectDto entity);

    [Get(EndPointConstantes.GET_ALL_PROJECTS)]
    public Task<IEnumerable<ProjectDto>> GetAll();

    [Get(EndPointConstantes.GET_ALL_PROJECTS_OF_ONE_TEAM)]
    public Task<IEnumerable<ProjectDto>> GetAllProjectsOfOneTeam(int idTeam);

    [Get(EndPointConstantes.GET_PROJECT)]
    public Task<ProjectDto> Get(int id);

    [Delete(EndPointConstantes.DELETE_PROJECT)]
    public Task<ProjectDto> Delete(ProjectDto entity);
}