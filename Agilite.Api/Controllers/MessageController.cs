using Agilite.Api.Messaging.Commands.MessageCommands.CreateMessage;
using Agilite.Api.Messaging.Commands.MessageCommands.DeleteMessage;
using Agilite.Api.Messaging.Commands.MessageCommands.GetAllMessages;
using Agilite.Api.Messaging.Commands.MessageCommands.GetMessage;
using Agilite.Api.Messaging.Commands.MessageCommands.UpdateMessage;
using Agilite.DataTransferObject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly ISender _sender;

    public MessageController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(nameof(CreateMessage))]
    public async Task<MessageDto> CreateMessage(MessageDto message)
        => await _sender.Send(new CreateMessageCommand(message));

    [HttpPut(nameof(UpdateMessage))]
    public async Task<MessageDto> UpdateMessage(MessageDto message)
        => await _sender.Send(new UpdateMessageCommand(message));

    [HttpGet(nameof(GetAllMessages))]
    public async Task<IEnumerable<MessageDto>> GetAllMessages()
        => await _sender.Send(new GetAllMessagesCommand());

    [HttpGet(nameof(GetMessage))]
    public async Task<MessageDto> GetMessage(int id)
        => await _sender.Send(new GetMessageCommand(id));

    [HttpDelete(nameof(DeleteMessage))]
    public async Task<MessageDto> DeleteMessage(MessageDto message)
        => await _sender.Send(new DeleteMessageCommand(message));
}