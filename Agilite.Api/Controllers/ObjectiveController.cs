using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ObjectiveController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IService<Objective> _service;

    public ObjectiveController(IMapper mapper, IService<Objective> service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPost(nameof(CreateObjective))]
    public ObjectiveDto CreateObjective([FromBody] ObjectiveDto objective)
    {
        var entity = _mapper.Map<Objective>(objective);
        var create = _service.Create(entity);
        return _mapper.Map<ObjectiveDto>(create);
    }

    [HttpPut(nameof(UpdateObjective))]
    public ObjectiveDto UpdateObjective([FromBody] ObjectiveDto objective)
    {
        var entity = _mapper.Map<Objective>(objective);
        var update = _service.Update(entity);
        return _mapper.Map<ObjectiveDto>(update);
    }

    [HttpGet(nameof(GetAllObjectives))]
    public IEnumerable<ObjectiveDto> GetAllObjectives()
    {
        var getAll = _service.GetAll();
        var entities = _mapper.Map<IEnumerable<ObjectiveDto>>(getAll);
        return entities;
    }

    [HttpGet(nameof(GetObjective))]
    public ObjectiveDto GetObjective(int id)
    {
        var getById = _service.GetById(id);
        var entity = _mapper.Map<ObjectiveDto>(getById);
        return entity;
    }

    [HttpDelete(nameof(DeleteObjective))]
    public ObjectiveDto DeleteObjective([FromBody] ObjectiveDto objective)
    {
        var entity = _mapper.Map<Objective>(objective);
        var delete = _service.Delete(entity);
        return _mapper.Map<ObjectiveDto>(delete);
    }
}