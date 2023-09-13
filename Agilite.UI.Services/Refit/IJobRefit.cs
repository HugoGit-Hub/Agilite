using Agilite.DataTransferObject;
using Refit;

namespace Agilite.UI.Services.Refit;

public interface IJobRefit : IBaseRefitClient
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