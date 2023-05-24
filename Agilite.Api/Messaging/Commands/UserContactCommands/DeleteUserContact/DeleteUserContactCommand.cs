using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserContactCommands.DeleteUserContact;

public sealed record DeleteUserContactCommand(UserContactDto UserContact) : IRequest<UserContactDto>;