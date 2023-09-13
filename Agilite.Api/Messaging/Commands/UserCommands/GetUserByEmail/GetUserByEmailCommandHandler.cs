using Agilite.DataTransferObject;
using Agilite.Services;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserCommands.GetUserByEmail;

public class GetUserByEmailCommandHandler : IRequestHandler<GetUserByEmailCommand, UserDto>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetUserByEmailCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserByEmailCommand request, CancellationToken cancellationToken)
    {
        var result = await _userService.GetUserByEmail(request.Email, cancellationToken);
        return _mapper.Map<UserDto>(result);
    }
}