using Agilite.DataTransferObject.DTOs;
using Agilite.Services;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamCommands.GetAllTeamsOfOneUser;

public class GetAllTeamsOfOneUserCommandHandler : IRequestHandler<GetAllTeamsOfOneUserCommand, IEnumerable<TeamDto>>
{
    private readonly IMapper _mapper;
    private readonly ITeamService _service;

    public GetAllTeamsOfOneUserCommandHandler(IMapper mapper, ITeamService service)
    {
        _mapper = mapper;
        _service = service;
    }

    public async Task<IEnumerable<TeamDto>> Handle(GetAllTeamsOfOneUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _service.GetAllTeamsOfOneUser(request.IdUser, cancellationToken);
        return _mapper.Map<IEnumerable<TeamDto>>(result);
    }
}