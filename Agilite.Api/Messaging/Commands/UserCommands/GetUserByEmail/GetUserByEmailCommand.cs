using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserCommands.GetUserByEmail;

public record GetUserByEmailCommand(string Email) : IRequest<UserDto>;