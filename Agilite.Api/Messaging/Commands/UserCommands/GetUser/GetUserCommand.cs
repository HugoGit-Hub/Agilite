using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserCommands.GetUser;

public sealed record GetUserCommand(int id) : IRequest<UserDto>;