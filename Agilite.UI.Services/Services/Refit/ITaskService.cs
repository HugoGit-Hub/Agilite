using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface ITaskService : IBaseRefitClient
{
    [Post(EndPointConstantes.CREATE_TASK)]
    public TaskDto Create(TaskDto entity);

    [Put(EndPointConstantes.UPDATE_TASK)]
    public TaskDto Update(TaskDto entity);

    [Get(EndPointConstantes.GET_ALL_TASKS)]
    public Task<IEnumerable<TaskDto>> GetAll();

    [Get(EndPointConstantes.GET_TASK)]
    public TaskDto Get(int id);

    [Delete(EndPointConstantes.DELETE_TASK)]
    public TaskDto Delete(TaskDto entity);
}