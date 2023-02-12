using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ContactCommands.GetAllContacts;

public sealed record GetAllContactsCommand : IRequest<IEnumerable<ContactDto>>;