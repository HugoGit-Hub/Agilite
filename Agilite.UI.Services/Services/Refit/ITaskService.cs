using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface ITaskService : IBaseRefitClient
{
    [Post(EndPointConstantes.CreateTask)]
    public JobDto Create(JobDto entity);

    [Put(EndPointConstantes.UpdateTask)]
    public JobDto Update(JobDto entity);

    [Get(EndPointConstantes.AllTasks)]
    public Task<IEnumerable<JobDto>> GetAll();

    [Get(EndPointConstantes.Task)]
    public JobDto Get(int id);

    [Delete(EndPointConstantes.DeleteTask)]
    public JobDto Delete(JobDto entity);
}