using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services;

public interface ISprintService
{
    [Post(EndPointConstantes.CREATE_SPRINT)]
    public SprintDto Create(SprintDto entity);

    [Put(EndPointConstantes.UPDATE_SPRINT)]
    public SprintDto Update(SprintDto entity);

    [Get(EndPointConstantes.GET_ALL_SPRINTS)]
    public Task<IEnumerable<SprintDto>> GetAll();

    [Get(EndPointConstantes.GET_SPRINT)]
    public SprintDto Get(int id);

    [Delete(EndPointConstantes.DELETE_SPRINT)]
    public SprintDto Delete(SprintDto entity);
}