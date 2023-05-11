using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface IPlanningService : IBaseRefitClient
{
    [Post(EndPointConstantes.CREATE_PLANNING)]
    public PlanningDto Create(PlanningDto entity);

    [Put(EndPointConstantes.UPDATE_PLANNING)]
    public PlanningDto Update(PlanningDto entity);

    [Get(EndPointConstantes.GET_ALL_PLANNINGS)]
    public Task<IEnumerable<PlanningDto>> GetAll();

    [Get(EndPointConstantes.GET_PLANNING)]
    public PlanningDto Get(int id);

    [Delete(EndPointConstantes.DELETE_PLANNING)]
    public PlanningDto Delete(PlanningDto entity);
}