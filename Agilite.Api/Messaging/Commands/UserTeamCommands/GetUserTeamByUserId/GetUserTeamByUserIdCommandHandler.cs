using Agilite.DataTransferObject.DTOs;
using Agilite.Services;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserTeamCommands.GetUserTeamByUserId;

public class GetUserTeamByUserIdCommandHandler : IRequestHandler<GetUserTeamByUserIdCommand, IEnumerable<UserTeamDto>>
{
    private readonly IMapper _mapper;
    private readonly IUserTeamService _userTeamService;

    public GetUserTeamByUserIdCommandHandler(IMapper mapper, IUserTeamService userTeamService)
    {
        _mapper = mapper;
        _userTeamService = userTeamService;
    }

    public Task<IEnumerable<UserTeamDto>> Handle(GetUserTeamByUserIdCommand request, CancellationToken cancellationToken)
    {
        var userTeams = _userTeamService.GetUserTeamByUserId(request.Id);
        return Task.FromResult(_mapper.Map<IEnumerable<UserTeamDto>>(userTeams));
    }
}