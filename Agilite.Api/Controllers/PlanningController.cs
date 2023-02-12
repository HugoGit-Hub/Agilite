using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanningController : Controller
{
    private readonly IMapper _mapper;
    private readonly IService<Planning> _service;

    public PlanningController(IMapper mapper, IService<Planning> service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPost(nameof(CreatePlanning))]
    public PlanningDto CreatePlanning([FromBody] PlanningDto planning)
    {
        var entity = _mapper.Map<Planning>(planning);
        var create = _service.Create(entity);
        return _mapper.Map<PlanningDto>(create);
    }

    [HttpPut(nameof(UpdatePlanning))]
    public PlanningDto UpdatePlanning([FromBody] PlanningDto planning )
    {
        var entity = _mapper.Map<Planning>(planning);
        var update = _service.Update(entity);
        return _mapper.Map<PlanningDto>(update);
    }

    [HttpGet(nameof(GetAllPlannings))]
    public IEnumerable<PlanningDto> GetAllPlannings()
    {
        var getAll = _service.GetAll();
        var entities = _mapper.Map<IEnumerable<PlanningDto>>(getAll);
        return entities;
    }

    [HttpGet(nameof(GetPlanning))]
    public PlanningDto GetPlanning(int id)
    {
        var getById = _service.GetById(id);
        var entity = _mapper.Map<PlanningDto>(getById);
        return entity;
    }

    [HttpDelete(nameof(DeletePlanning))]
    public PlanningDto DeletePlanning([FromBody] PlanningDto planning)
    {
        var entity = _mapper.Map<Planning>(planning);
        var delete = _service.Delete(entity);
        return _mapper.Map<PlanningDto>(delete);
    }
}