using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserCommands.CreateUser;

public sealed record CreateUserCommand(UserDto User) : IRequest<UserDto>;