using Agilite.Api.Messaging.Commands.UserContactCommands.CreateUserContact;
using Agilite.Api.Messaging.Commands.UserContactCommands.DeleteUserContact;
using Agilite.Api.Messaging.Commands.UserContactCommands.GetAllUserContacts;
using Agilite.Api.Messaging.Commands.UserContactCommands.GetUserContact;
using Agilite.Api.Messaging.Commands.UserContactCommands.UpdateUserContact;
using Agilite.DataTransferObject.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContactController : ControllerBase
    {
        private readonly ISender _sender;

        public UserContactController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost(nameof(CreateUserContact))]
        public async Task<UserContactDto> CreateUserContact(UserContactDto userContact)
            => await _sender.Send(new CreateUserContactCommand(userContact));

        [HttpPut(nameof(UpdateUserContact))]
        public async Task<UserContactDto> UpdateUserContact(UserContactDto userContact)
            => await _sender.Send(new UpdateUserContactCommand(userContact));

        [HttpGet(nameof(GetAllUserContacts))]
        public async Task<IEnumerable<UserContactDto>> GetAllUserContacts()
            => await _sender.Send(new GetAllUserContactsCommand());

        [HttpGet(nameof(GetUserContact))]
        public async Task<UserContactDto> GetUserContact(int id)
            => await _sender.Send(new GetUserContactCommand(id));

        [HttpDelete(nameof(DeleteUserContact))]
        public async Task<UserContactDto> DeleteUserContact(UserContactDto userContact)
            => await _sender.Send(new DeleteUserContactCommand(userContact));
    }
}
