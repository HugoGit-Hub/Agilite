using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ContactCommands.UpdateContact;

public sealed record UpdateContactCommand(ContactDto Contact) : IRequest<ContactDto>;