using Agilite.DataTransferObject.DTOs;
using Agilite.Services;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamCommands.GetAllProjectsOfOneTeam;

public class GetAllProjectsOfOneTeamCommandHandler : IRequestHandler<GetAllProjectsOfOneTeamCommand, IEnumerable<ProjectDto>>
{
    private readonly IMapper _mapper;
    private readonly ITeamService _projectService;

    public GetAllProjectsOfOneTeamCommandHandler(IMapper mapper, ITeamService projectService)
    {
        _mapper = mapper;
        _projectService = projectService;
    }

    public async Task<IEnumerable<ProjectDto>> Handle(GetAllProjectsOfOneTeamCommand request, CancellationToken cancellationToken)
    {
        var result = await _projectService.GetAllProjectsOfOneTeam(request.IdTeam, cancellationToken);
        return _mapper.Map<IEnumerable<ProjectDto>>(result);
    }
}