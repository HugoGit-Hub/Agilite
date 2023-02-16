using Agilite.Api.Messaging.Commands.UserMessageContactCommands.CreateUserMessageContact;
using Agilite.Api.Messaging.Commands.UserMessageContactCommands.DeleteUserMessageContact;
using Agilite.Api.Messaging.Commands.UserMessageContactCommands.GetAllUserMessageContacts;
using Agilite.Api.Messaging.Commands.UserMessageContactCommands.UpdateUserMessageContact;
using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserMessageContactController : ControllerBase
{
    private readonly ISender _sender;

    public UserMessageContactController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(nameof(CreateUserMessageContact))]
    public async Task<UserMessageContactDto> CreateUserMessageContact(UserMessageContactDto userMessageContact)
        => await _sender.Send(new CreateUserMessageContactCommand(userMessageContact));

    [HttpPut(nameof(UpdateUserMessageContact))]
    public async Task<UserMessageContactDto> UpdateUserMessageContact(UserMessageContact userMessageContact)
        => await _sender.Send(new UpdateUserMessageContactCommand(userMessageContact));

    [HttpGet(nameof(GetAllUserMessageContacts))]
    public async Task<IEnumerable<UserMessageContactDto>> GetAllUserMessageContacts()
        => await _sender.Send(new GetAllUserMessageContactsCommand());

    [HttpDelete(nameof(DeleteUserMessageContact))]
    public async Task<UserMessageContactDto> DeleteUserMessageContact(UserMessageContactDto userMessageContact)
        => await _sender.Send(new DeleteUserMessageContactCommand(userMessageContact));
}