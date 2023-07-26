using Agilite.DataTransferObject.DTOs;
using Agilite.Services;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserCommands.GetAllTeamsOfOneUser;

public class GetAllTeamsOfOneUserCommandHandler : IRequestHandler<GetAllTeamsOfOneUserCommand, IEnumerable<TeamDto>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetAllTeamsOfOneUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TeamDto>> Handle(GetAllTeamsOfOneUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _userService.GetAllTeamsOfOneUser(request.IdUser, cancellationToken);
        return _mapper.Map<IEnumerable<TeamDto>>(result);
    }
}