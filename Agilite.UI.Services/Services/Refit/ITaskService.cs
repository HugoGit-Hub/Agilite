using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface ITaskService : IBaseRefitClient
{
    [Post(EndPointConstantes.CREATE_TASK)]
    public JobDto Create(JobDto entity);

    [Put(EndPointConstantes.UPDATE_TASK)]
    public JobDto Update(JobDto entity);

    [Get(EndPointConstantes.GET_ALL_TASKS)]
    public Task<IEnumerable<JobDto>> GetAll();

    [Get(EndPointConstantes.GET_TASK)]
    public JobDto Get(int id);

    [Delete(EndPointConstantes.DELETE_TASK)]
    public JobDto Delete(JobDto entity);
}