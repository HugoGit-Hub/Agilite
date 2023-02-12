using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserMessageContactController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IService<UserMessageContact> _service;

    public UserMessageContactController(IMapper mapper, IService<UserMessageContact> service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPost(nameof(CreateUserMessageContact))]
    public UserMessageContactDto CreateUserMessageContact([FromBody] UserMessageContactDto userMessageContact)
    {
        var entity = _mapper.Map<UserMessageContact>(userMessageContact);
        var create = _service.Create(entity);
        return _mapper.Map<UserMessageContactDto>(create);
    }

    [HttpPut(nameof(UpdateUserMessageContact))]
    public UserMessageContactDto UpdateUserMessageContact([FromBody] UserMessageContactDto userMessageContact)
    {
        var entity = _mapper.Map<UserMessageContact>(userMessageContact);
        var update = _service.Update(entity);
        return _mapper.Map<UserMessageContactDto>(update);
    }

    [HttpGet(nameof(GetAllUserMessageContacts))]
    public IEnumerable<UserMessageContactDto> GetAllUserMessageContacts()
    {
        var getAll = _service.GetAll();
        var entities = _mapper.Map<IEnumerable<UserMessageContactDto>>(getAll);
        return entities;
    }

    [HttpGet(nameof(GetUserMessageContact))]
    public UserMessageContactDto GetUserMessageContact(int id)
    {
        var getById = _service.GetById(id);
        var entity = _mapper.Map<UserMessageContactDto>(getById);
        return entity;
    }

    [HttpDelete(nameof(DeleteUserMessageContact))]
    public UserMessageContactDto DeleteUserMessageContact([FromBody] UserMessageContactDto userMessageContact)
    {
        var entity = _mapper.Map<UserMessageContact>(userMessageContact);
        var delete = _service.Delete(entity);
        return _mapper.Map<UserMessageContactDto>(delete);
    }
}