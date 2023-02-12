using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserTeamTeamRoleController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IService<UserTeamTeamRole> _service;

    public UserTeamTeamRoleController(IMapper mapper, IService<UserTeamTeamRole> service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPost(nameof(CreateUserTeamTeamRole))]
    public UserTeamTeamRoleDto CreateUserTeamTeamRole([FromBody] UserTeamTeamRoleDto userTeamTeamRole)
    {
        var entity = _mapper.Map<UserTeamTeamRole>(userTeamTeamRole);
        var create = _service.Create(entity);
        return _mapper.Map<UserTeamTeamRoleDto>(create);
    }

    [HttpPut(nameof(UpdateUserTeamTeamRole))]
    public UserTeamTeamRoleDto UpdateUserTeamTeamRole([FromBody] UserTeamTeamRoleDto userTeamTeamRole)
    {
        var entity = _mapper.Map<UserTeamTeamRole>(userTeamTeamRole);
        var update = _service.Update(entity);
        return _mapper.Map<UserTeamTeamRoleDto>(update);
    }

    [HttpGet(nameof(GetAllUserTeamTeamRoles))]
    public IEnumerable<UserTeamTeamRoleDto> GetAllUserTeamTeamRoles()
    {
        var getAll = _service.GetAll();
        var entities = _mapper.Map<IEnumerable<UserTeamTeamRoleDto>>(getAll);
        return entities;
    }

    [HttpGet(nameof(GetUserTeamTeamRole))]
    public ContactDto GetUserTeamTeamRole(int id)
    {
        var getById = _service.GetById(id);
        var entity = _mapper.Map<ContactDto>(getById);
        return entity;
    }

    [HttpDelete(nameof(DeleteUserTeamTeamRole))]
    public UserTeamTeamRoleDto DeleteUserTeamTeamRole([FromBody] UserTeamTeamRoleDto userTeamTeamRole)
    {
        var entity = _mapper.Map<UserTeamTeamRole>(userTeamTeamRole);
        var delete = _service.Delete(entity);
        return _mapper.Map<UserTeamTeamRoleDto>(delete);
    }
}