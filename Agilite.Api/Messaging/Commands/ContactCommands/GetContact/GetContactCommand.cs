using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ContactCommands.GetContact;

public sealed record GetContactCommand(int id) : IRequest<ContactDto>;