using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserCommands.GetAllUsers;

public sealed record GetAllUsersCommand : IRequest<IEnumerable<UserDto>>;