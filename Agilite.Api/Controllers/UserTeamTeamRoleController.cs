using Agilite.Api.Messaging.Commands.UserTeamTeamRoleCommands.CreateUserTeamTeamRole;
using Agilite.Api.Messaging.Commands.UserTeamTeamRoleCommands.DeleteUserTeamTeamRole;
using Agilite.Api.Messaging.Commands.UserTeamTeamRoleCommands.GetAllUserTeamTeamRoles;
using Agilite.Api.Messaging.Commands.UserTeamTeamRoleCommands.UpdateUserTeamTeamRole;
using Agilite.DataTransferObject.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserTeamTeamRoleController : ControllerBase
{
    private readonly ISender _sender;

    public UserTeamTeamRoleController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(nameof(CreateUserTeamTeamRole))]
    public async Task<UserTeamTeamRoleDto> CreateUserTeamTeamRole(UserTeamTeamRoleDto userTeamTeamRole)
        => await _sender.Send(new CreateUserTeamTeamRoleCommand(userTeamTeamRole));

    [HttpPut(nameof(UpdateUserTeamTeamRole))]
    public async Task<UserTeamTeamRoleDto> UpdateUserTeamTeamRole(UserTeamTeamRoleDto userTeamTeamRole)
        => await _sender.Send(new UpdateUserTeamTeamRoleCommand(userTeamTeamRole));

    [HttpGet(nameof(GetAllUserTeamTeamRoles))]
    public async Task<IEnumerable<UserTeamTeamRoleDto>> GetAllUserTeamTeamRoles()
        => await _sender.Send(new GetAllUserTeamTeamRolesCommand());

    [HttpDelete(nameof(DeleteUserTeamTeamRole))]
    public async Task<UserTeamTeamRoleDto> DeleteUserTeamTeamRole(UserTeamTeamRoleDto userTeamTeamRole)
        => await _sender.Send(new DeleteUserTeamTeamRoleCommand(userTeamTeamRole));
}