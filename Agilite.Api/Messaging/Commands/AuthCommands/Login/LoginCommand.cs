using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.AuthCommands.Login;

public record LoginCommand(LoginDto Login) : IRequest<string>;