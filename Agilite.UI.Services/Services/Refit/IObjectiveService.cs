using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface IObjectiveService : IBaseRefitClient
{
    [Post(EndPointConstantes.CreateObjective)]
    public ObjectiveDto Create(ObjectiveDto entity);

    [Put(EndPointConstantes.UpdateObjective)]
    public ObjectiveDto Update(ObjectiveDto entity);

    [Get(EndPointConstantes.AllObjectives)]
    public Task<IEnumerable<ObjectiveDto>> GetAll();

    [Get(EndPointConstantes.Objective)]
    public ObjectiveDto Get(int id);

    [Delete(EndPointConstantes.DeleteObjective)]
    public ObjectiveDto Delete(ObjectiveDto entity);
}