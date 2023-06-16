using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.Services;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserCommands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserSerice _userSerice;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserSerice userSerice, IMapper mapper)
    {
        _userSerice = userSerice;
        _mapper = mapper;
    }

    public Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request.User);
        var created = _userSerice.CreateUser(user);
        return Task.FromResult(_mapper.Map<UserDto>(created));
    }
}
