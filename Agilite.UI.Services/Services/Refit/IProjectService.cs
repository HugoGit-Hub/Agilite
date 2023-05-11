using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface IProjectService : IBaseRefitClient
{
    [Post(EndPointConstantes.CREATE_PROJECT)]
    public ProjectDto Create(ProjectDto entity);

    [Put(EndPointConstantes.UPDATE_PROJECT)]
    public ProjectDto Update(ProjectDto entity);

    [Get(EndPointConstantes.GET_ALL_PROJECTS)]
    public Task<IEnumerable<ProjectDto>> GetAll();

    [Get(EndPointConstantes.GET_PROJECT)]
    public ProjectDto Get(int id);

    [Delete(EndPointConstantes.DELETE_PROJECT)]
    public ProjectDto Delete(ProjectDto entity);
}