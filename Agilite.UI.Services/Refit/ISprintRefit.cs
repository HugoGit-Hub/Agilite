using Agilite.DataTransferObject;
using Refit;

namespace Agilite.UI.Services.Refit;

public interface ISprintRefit : IBaseRefitClient
{
    [Post(EndPointConstantes.CreateSprint)]
    public Task<SprintDto> Create(SprintDto sprint);

    [Put(EndPointConstantes.UpdateSprint)]
    public Task<SprintDto> Update(SprintDto entity);

    [Get(EndPointConstantes.AllSprints)]
    public Task<IEnumerable<SprintDto>> GetAll();
    
    [Get(EndPointConstantes.AllSprintsOfOneProject)]
    public Task<IEnumerable<SprintDto>> GetAllSprintsOfOneProject(int idProject);

    [Get(EndPointConstantes.Sprint)]
    public Task<SprintDto> Get(int id);

    [Delete(EndPointConstantes.DeleteSprint)]
    public Task<SprintDto> Delete(SprintDto entity);
}