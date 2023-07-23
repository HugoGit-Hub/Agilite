using Agilite.Api.Messaging.Commands.TeamCommands.CreateTeam;
using Agilite.Api.Messaging.Commands.TeamCommands.CreateTeamUser;
using Agilite.Api.Messaging.Commands.TeamCommands.DeleteTeam;
using Agilite.Api.Messaging.Commands.TeamCommands.GetAllTeams;
using Agilite.Api.Messaging.Commands.TeamCommands.GetTeam;
using Agilite.Api.Messaging.Commands.TeamCommands.UpdateTeam;
using Agilite.DataTransferObject.DTOs;
using Agilite.UnitOfWork.Context;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamController : ControllerBase
{

    private readonly ISender _sender;
    private readonly AgiliteContext _context;
    private readonly IMapper _mapper;

    public TeamController(ISender sender, AgiliteContext context, IMapper mapper)
    {
        _sender = sender;
        _context = context;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateTeam))]
    public async Task<TeamDto> CreateTeam(TeamDto team)
        => await _sender.Send(new CreateTeamCommand(team));

    [HttpPost(nameof(CreateTeamUser))]
    public async Task<TeamDto> CreateTeamUser(int idTeam, int idUser, CancellationToken cancellationToken)
        => await _sender.Send(new CreateTeamUserCommand(idTeam, idUser), cancellationToken);
    //{
    //    var team = await _context.Teams.SingleOrDefaultAsync(team => team.IdTeam == idTeam);
    //    var user = await _context.Users.SingleOrDefaultAsync(user => user.IdUser == idUser);
    //    if (user != null) team?.Users.Add(user);

    //    await _context.SaveChangesAsync();

    //    var result = await _context.Teams.Where(e => e.IdTeam == idTeam).SingleAsync();
    //    return _mapper.Map<TeamDto>(result);
    //}

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