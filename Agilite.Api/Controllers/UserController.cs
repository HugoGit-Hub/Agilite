using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IService<User> _service;

    public UserController(IMapper mapper, IService<User> service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPost(nameof(CreateUser))]
    public UserDto CreateUser([FromBody] UserDto user)
    {
        var entity = _mapper.Map<User>(user);
        var create = _service.Create(entity);
        return _mapper.Map<UserDto>(create);
    }

    [HttpPut(nameof(UpdateUser))]
    public UserDto UpdateUser([FromBody] UserDto user)
    {
        var entity = _mapper.Map<User>(user);
        var update = _service.Update(entity);
        return _mapper.Map<UserDto>(update);
    }

    [HttpGet(nameof(GetAllUsers))]
    public IEnumerable<UserDto> GetAllUsers()
    {
        var getAll = _service.GetAll();            
        var entities = _mapper.Map<IEnumerable<UserDto>>(getAll);
        return entities;
    }

    [HttpGet(nameof(GetUser))]
    public UserDto GetUser(int id)
    {
        var getById= _service.GetById(id);
        var entity = _mapper.Map<UserDto>(getById);
        return entity;
    }

    [HttpDelete(nameof(DeleteUser))]
    public UserDto DeleteUser([FromBody] UserDto user)
    {
        var entity = _mapper.Map<User>(user);
        var delete = _service.Delete(entity);
        return _mapper.Map<UserDto>(delete);
    }
}