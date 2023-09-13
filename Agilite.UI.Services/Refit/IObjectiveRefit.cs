using Agilite.DataTransferObject;
using Refit;

namespace Agilite.UI.Services.Refit;

public interface IObjectiveRefit : IBaseRefitClient
{
    [Post(EndPointConstantes.CreateObjective)]
    public Task<ObjectiveDto> Create(ObjectiveDto entity);

    [Put(EndPointConstantes.UpdateObjective)]
    public Task<ObjectiveDto> Update(ObjectiveDto entity);

    [Get(EndPointConstantes.GetAllObjectivesOfOneSprint)]
    public Task<IEnumerable<ObjectiveDto>> GetAllOfOneSprint(int sprintId);

    [Get(EndPointConstantes.AllObjectives)]
    public Task<IEnumerable<ObjectiveDto>> GetAll();

    [Get(EndPointConstantes.Objective)]
    public Task<ObjectiveDto> Get(int id);

    [Delete(EndPointConstantes.DeleteObjective)]
    public Task<ObjectiveDto> Delete(ObjectiveDto entity);
}