using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ContactCommands.CreateContact;

public sealed record CreateContactCommand(string NameContact) : IRequest<ContactDto>;