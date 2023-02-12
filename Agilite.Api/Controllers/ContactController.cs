using Agilite.Api.Messaging.Commands.ContactCommands.CreateContact;
using Agilite.Api.Messaging.Commands.ContactCommands.DeleteContact;
using Agilite.Api.Messaging.Commands.ContactCommands.GetAllContacts;
using Agilite.Api.Messaging.Commands.ContactCommands.GetContact;
using Agilite.Api.Messaging.Commands.ContactCommands.UpdateContact;
using Agilite.DataTransferObject.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly ISender _sender;

    public ContactController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(nameof(CreateContact))]
    public async Task<ContactDto> CreateContact(string contactName)
        => await _sender.Send(new CreateContactCommand(contactName));

    [HttpPut(nameof(UpdateContact))]
    public async Task<ContactDto> UpdateContact(ContactDto contact)
        => await _sender.Send(new UpdateContactCommand(contact));

    [HttpGet(nameof(GetAllContacts))]
    public async Task<IEnumerable<ContactDto>> GetAllContacts()
        => await _sender.Send(new GetAllContactsCommand());

    [HttpGet(nameof(GetContact))]
    public async Task<ContactDto> GetContact(int id)
        => await _sender.Send(new GetContactCommand(id));

    [HttpDelete(nameof(DeleteContact))]
    public async Task<ContactDto> DeleteContact(ContactDto contact)
        => await _sender.Send(new DeleteContactCommand(contact));
}