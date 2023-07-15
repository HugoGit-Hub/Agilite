using Agilite.Api.Messaging.Commands.UserCommands.CreateUser;
using Agilite.Api.Messaging.Commands.UserCommands.DeleteUser;
using Agilite.Api.Messaging.Commands.UserCommands.GetAllUsers;
using Agilite.Api.Messaging.Commands.UserCommands.GetUser;
using Agilite.Api.Messaging.Commands.UserCommands.GetUserByEmail;
using Agilite.Api.Messaging.Commands.UserCommands.UpdateUser;
using Agilite.DataTransferObject.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(nameof(CreateUser))]
    public async Task<UserDto> CreateUser(UserDto user)
        => await _sender.Send(new CreateUserCommand(user));

    [HttpPut(nameof(UpdateUser))]
    public async Task<UserDto> UpdateUser(UserDto user)
        => await _sender.Send(new UpdateUserCommand(user));

    [HttpGet(nameof(GetAllUsers))]
    public async Task<IEnumerable<UserDto>> GetAllUsers()
        => await _sender.Send(new GetAllUsersCommand());

    [HttpGet(nameof(GetUser))]
    public async Task<UserDto> GetUser(int id)
        => await _sender.Send(new GetUserCommand(id));

    [HttpGet(nameof(GetUserByEmail))]
    public async Task<UserDto> GetUserByEmail(string email)
        => await _sender.Send(new GetUserByEmailCommand(email));

    [HttpDelete(nameof(DeleteUser))]
    public async Task<UserDto> DeleteUser(UserDto user)
        => await _sender.Send(new DeleteUserCommand(user));
}