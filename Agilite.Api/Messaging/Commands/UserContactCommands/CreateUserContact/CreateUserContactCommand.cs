using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserContactCommands.CreateUserContact;

public sealed record CreateUserContactCommand(UserContactDto UserContact) : IRequest<UserContactDto>;