using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services;

public interface IObjectiveService
{
    [Post(EndPointConstantes.CREATE_OBJECTIVE)]
    public ObjectiveDto Create(ObjectiveDto entity);

    [Put(EndPointConstantes.UPDATE_OBJECTIVE)]
    public ObjectiveDto Update(ObjectiveDto entity);

    [Get(EndPointConstantes.GET_ALL_OBJECTIVES)]
    public Task<IEnumerable<ObjectiveDto>> GetAll();

    [Get(EndPointConstantes.GET_OBJECTIVE)]
    public ObjectiveDto Get(int id);

    [Delete(EndPointConstantes.DELETE_OBJECTIVE)]
    public ObjectiveDto Delete(ObjectiveDto entity);
}