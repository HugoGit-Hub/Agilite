using Agilite.Api.Messaging.Commands.MessageCommands.CreateMessage;
using Agilite.Api.Messaging.Commands.MessageCommands.DeleteMessage;
using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    private readonly IService<Message> _service;

    public MessageController(IMapper mapper, IService<Message> service, ISender sender)
    {
        _mapper = mapper;
        _service = service;
        _sender = sender;
    }

    [HttpPost(nameof(CreateMessage))]
    public async Task<MessageDto> CreateMessage(MessageDto message)
        => await _sender.Send(new CreateMessageCommand(message));

    [HttpPut(nameof(UpdateMessage))]
    public async Task<MessageDto> UpdateMessage(MessageDto message)
        => await _sender.Send(new DeleteMessageCommand(message));

    [HttpGet(nameof(GetAllMessages))]
    public IEnumerable<MessageDto> GetAllMessages()
    {
        var getAll = _service.GetAll();
        var entities = _mapper.Map<IEnumerable<MessageDto>>(getAll);
        return entities;
    }

    [HttpGet(nameof(GetMessage))]
    public UserDto GetMessage(int id)
    {
        var getById = _service.GetById(id);
        var entity = _mapper.Map<UserDto>(getById);
        return entity;
    }

    [HttpDelete(nameof(DeleteMessage))]
    public MessageDto DeleteMessage([FromBody] MessageDto message)
    {
        var entity = _mapper.Map<Message>(message);
        var delete = _service.Delete(entity);
        return _mapper.Map<MessageDto>(delete);
    }
}