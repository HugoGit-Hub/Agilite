using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamRoleController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IService<TeamRole> _service;

    public TeamRoleController(IMapper mapper, IService<TeamRole> service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPost(nameof(CreateTeamRole))]
    public TeamRoleDto CreateTeamRole([FromBody] TeamRoleDto teamRole)
    {
        var entity = _mapper.Map<TeamRole>(teamRole);
        var create = _service.Create(entity);
        return _mapper.Map<TeamRoleDto>(create);
    }

    [HttpPut(nameof(UpdateTeamRole))]
    public TeamRoleDto UpdateTeamRole([FromBody] TeamRoleDto teamRole)
    {
        var entity = _mapper.Map<TeamRole>(teamRole);
        var update = _service.Update(entity);
        return _mapper.Map<TeamRoleDto>(update);
    }

    [HttpGet(nameof(GetAllTeamRoles))]
    public IEnumerable<TeamRoleDto> GetAllTeamRoles()
    {
        var getAll = _service.GetAll();
        var entities = _mapper.Map<IEnumerable<TeamRoleDto>>(getAll);
        return entities;
    }

    [HttpGet(nameof(GetTeamRole))]
    public TeamRoleDto GetTeamRole(int id)
    {
        var getById = _service.GetById(id);
        var entity = _mapper.Map<TeamRoleDto>(getById);
        return entity;
    }

    [HttpDelete(nameof(DeleteTeamRole))]
    public TeamRoleDto DeleteTeamRole([FromBody] TeamRoleDto contact)
    {
        var entity = _mapper.Map<TeamRole>(contact);
        var delete = _service.Delete(entity);
        return _mapper.Map<TeamRoleDto>(delete);
    }
}