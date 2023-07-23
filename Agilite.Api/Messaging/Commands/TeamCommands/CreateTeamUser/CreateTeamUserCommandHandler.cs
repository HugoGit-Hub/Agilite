using Agilite.DataTransferObject.DTOs;
using Agilite.Services;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamCommands.CreateTeamUser;

public class CreateTeamUserCommandHandler : IRequestHandler<CreateTeamUserCommand, TeamDto>
{
    private readonly IMapper _mapper;
    private readonly ITeamService _teamService;

    public CreateTeamUserCommandHandler(IMapper mapper, ITeamService teamService)
    {
        _mapper = mapper;
        _teamService = teamService;
    }

    public async Task<TeamDto> Handle(CreateTeamUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _teamService.CreateTeamUser(request.IdTeam, request.IdUser, cancellationToken);
        return _mapper.Map<TeamDto>(result);
    }
}
