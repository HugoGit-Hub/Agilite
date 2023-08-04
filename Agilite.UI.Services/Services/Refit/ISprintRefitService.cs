using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface ISprintRefitService : IBaseRefitClient
{
    [Post(EndPointConstantes.CREATE_SPRINT)]
    public Task<SprintDto> Create(SprintDto entity);

    [Put(EndPointConstantes.UPDATE_SPRINT)]
    public Task<SprintDto> Update(SprintDto entity);

    [Get(EndPointConstantes.GET_ALL_SPRINTS)]
    public Task<IEnumerable<SprintDto>> GetAll();
    
    [Get(EndPointConstantes.GET_ALL_SPRINTS_OF_ONE_PROJECT)]
    public Task<IEnumerable<SprintDto>> GetAllSprintsOfOneProject(int idProject);

    [Get(EndPointConstantes.GET_SPRINT)]
    public Task<SprintDto> Get(int id);

    [Delete(EndPointConstantes.DELETE_SPRINT)]
    public Task<SprintDto> Delete(SprintDto entity);
}