using Agilite.DataTransferObject.DTOs;
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

    public Task<UserDto> Handle(GetUserByEmailCommand request, CancellationToken cancellationToken)
    {
        var user = _userService.GetUserByEmail(request.Email);
        return Task.FromResult(_mapper.Map<UserDto>(user));
    }
}