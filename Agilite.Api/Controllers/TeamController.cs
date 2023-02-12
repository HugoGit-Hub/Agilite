using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IService<Team> _service;

    public TeamController(IMapper mapper, IService<Team> service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPost(nameof(CreateTeam))]
    public TeamDto CreateTeam([FromBody] TeamDto team)
    {
        var entity = _mapper.Map<Team>(team);
        var create = _service.Create(entity);
        return _mapper.Map<TeamDto>(create);
    }

    [HttpPut(nameof(UpdateTeam))]
    public TeamDto UpdateTeam([FromBody] TeamDto team)
    {
        var entity = _mapper.Map<Team>(team);
        var update = _service.Update(entity);
        return _mapper.Map<TeamDto>(update);
    }

    [HttpGet(nameof(GetAllTeams))]
    public IEnumerable<TeamDto> GetAllTeams()
    {
        var getAll = _service.GetAll();
        var entities = _mapper.Map<IEnumerable<TeamDto>>(getAll);
        return entities;
    }

    [HttpGet(nameof(GetTeam))]
    public TeamDto GetTeam(int id)
    {
        var getById = _service.GetById(id);
        var entity = _mapper.Map<TeamDto>(getById);
        return entity;
    }

    [HttpDelete(nameof(DeleteTeam))]
    public TeamDto DeleteTeam([FromBody] TeamDto contact)
    {
        var entity = _mapper.Map<Team>(contact);
        var delete = _service.Delete(entity);
        return _mapper.Map<TeamDto>(delete);
    }
}