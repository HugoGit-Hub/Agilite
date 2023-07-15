using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserCommands.GetUserByEmail;

public record GetUserByEmailCommand(string Email) : IRequest<UserDto>;