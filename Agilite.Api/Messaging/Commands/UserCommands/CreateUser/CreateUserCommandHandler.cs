using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.Services;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserCommands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request.User);
        var result = _userService.CreateUser(user);
        return Task.FromResult(_mapper.Map<UserDto>(result));
    }
}
