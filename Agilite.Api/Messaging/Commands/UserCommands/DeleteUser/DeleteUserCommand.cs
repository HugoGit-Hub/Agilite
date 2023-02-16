using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserCommands.DeleteUser;

public sealed record DeleteUserCommand(UserDto User) : IRequest<UserDto>;