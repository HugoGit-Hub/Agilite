using Agilite.Api.Messaging.Commands.TeamCommands.CreateTeam;
using Agilite.Api.Messaging.Commands.TeamCommands.DeleteTeam;
using Agilite.Api.Messaging.Commands.TeamCommands.GetAllTeams;
using Agilite.Api.Messaging.Commands.TeamCommands.GetTeam;
using Agilite.Api.Messaging.Commands.TeamCommands.UpdateTeam;
using Agilite.DataTransferObject.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamController : ControllerBase
{

    private readonly ISender _sender;

    public TeamController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(nameof(CreateTeam))]
    public async Task<TeamDto> CreateTeam(TeamDto team)
        => await _sender.Send(new CreateTeamCommand(team));

    [HttpPut(nameof(UpdateTeam))]
    public async Task<TeamDto> UpdateTeam(TeamDto team)
        => await _sender.Send(new UpdateTeamCommand(team));

    [HttpGet(nameof(GetAllTeams))]
    public async Task<IEnumerable<TeamDto>> GetAllTeams()
        => await _sender.Send(new GetAllTeamsCommand());

    [HttpGet(nameof(GetTeam))]
    public async Task<TeamDto> GetTeam(int id)
        => await _sender.Send(new GetTeamCommand(id));

    [HttpDelete(nameof(DeleteTeam))]
    public async Task<TeamDto> DeleteTeam(TeamDto team)
        => await _sender.Send(new DeleteTeamCommand(team));
}