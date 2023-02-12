using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ContactCommands.DeleteContact;

public sealed record DeleteContactCommand(ContactDto contact) : IRequest<ContactDto>;