using Agilite.DataTransferObject;
using Agilite.Services;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ProjectCommands.GetAllProjectsOfOneTeam;

public class GetAllProjectsOfOneTeamCommandHandler : IRequestHandler<GetAllProjectsOfOneTeamCommand, IEnumerable<ProjectDto>>
{
    private readonly IMapper _mapper;
    private readonly IProjectService _service;

    public GetAllProjectsOfOneTeamCommandHandler(IMapper mapper, IProjectService service)
    {
        _mapper = mapper;
        _service = service;
    }

    public async Task<IEnumerable<ProjectDto>> Handle(GetAllProjectsOfOneTeamCommand request, CancellationToken cancellationToken)
    {
        var result = await _service.GetAllProjectsOfOneTeam(request.IdTeam, cancellationToken);
        return _mapper.Map<IEnumerable<ProjectDto>>(result);
    }
}