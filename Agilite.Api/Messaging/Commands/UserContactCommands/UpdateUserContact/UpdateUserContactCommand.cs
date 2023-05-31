using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserContactCommands.UpdateUserContact;

public sealed record UpdateUserContactCommand(UserContactDto UserContact) : IRequest<UserContactDto>;