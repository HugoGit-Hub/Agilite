using Agilite.Api.Messaging.Commands.TeamRoleCommands.CreateTeamRole;
using Agilite.Api.Messaging.Commands.TeamRoleCommands.DeleteTeamRole;
using Agilite.Api.Messaging.Commands.TeamRoleCommands.GetAllTeamRoles;
using Agilite.Api.Messaging.Commands.TeamRoleCommands.GetTeamRole;
using Agilite.Api.Messaging.Commands.TeamRoleCommands.UpdateTeamRole;
using Agilite.DataTransferObject.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamRoleController : ControllerBase
{
    private readonly ISender _sender;

    public TeamRoleController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(nameof(CreateTeamRole))]
    public async Task<TeamRoleDto> CreateTeamRole(TeamRoleDto teamRole)
        => await _sender.Send(new CreateTeamRoleCommand(teamRole));

    [HttpPut(nameof(UpdateTeamRole))]
    public async Task<TeamRoleDto> UpdateTeamRole(TeamRoleDto teamRole)
        => await _sender.Send(new UpdateTeamRoleCommand(teamRole));

    [HttpGet(nameof(GetAllTeamRoles))]
    public async Task<IEnumerable<TeamRoleDto>> GetAllTeamRoles()
        => await _sender.Send(new GetAllTeamRolesCommand());

    [HttpGet(nameof(GetTeamRole))]
    public async Task<TeamRoleDto> GetTeamRole(int id)
        => await _sender.Send(new GetTeamRoleCommand(id));

    [HttpDelete(nameof(DeleteTeamRole))]
    public async Task<TeamRoleDto> DeleteTeamRole(TeamRoleDto teamRole)
        => await _sender.Send(new DeleteTeamRoleCommand(teamRole));
}