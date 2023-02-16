using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserCommands.UpdateUser;

public sealed record UpdateUserCommand(UserDto User) : IRequest<UserDto>;