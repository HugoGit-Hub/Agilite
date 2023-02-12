using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SprintController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IService<Sprint> _service;

    public SprintController(IMapper mapper, IService<Sprint> service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPost(nameof(CreateSprint))]
    public SprintDto CreateSprint([FromBody] SprintDto sprint)
    {
        var entity = _mapper.Map<Sprint>(sprint);
        var create = _service.Create(entity);
        return _mapper.Map<SprintDto>(create);
    }

    [HttpPut(nameof(UpdateSprint))]
    public SprintDto UpdateSprint([FromBody] SprintDto sprint)
    {
        var entity = _mapper.Map<Sprint>(sprint);
        var update = _service.Update(entity);
        return _mapper.Map<SprintDto>(update);
    }

    [HttpGet(nameof(GetAllSprints))]
    public IEnumerable<SprintDto> GetAllSprints()
    {
        var getAll = _service.GetAll();
        var entities = _mapper.Map<IEnumerable<SprintDto>>(getAll);
        return entities;
    }

    [HttpGet(nameof(GetSprint))]
    public SprintDto GetSprint(int id)
    {
        var getById = _service.GetById(id);
        var entity = _mapper.Map<SprintDto>(getById);
        return entity;
    }

    [HttpDelete(nameof(DeleteSprint))]
    public SprintDto DeleteSprint([FromBody] SprintDto sprint)
    {
        var entity = _mapper.Map<Sprint>(sprint);
        var delete = _service.Delete(entity);
        return _mapper.Map<SprintDto>(delete);
    }
}