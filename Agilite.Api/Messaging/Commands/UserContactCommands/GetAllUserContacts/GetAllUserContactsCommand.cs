using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserContactCommands.GetAllUserContacts;

public sealed record GetAllUserContactsCommand : IRequest<IEnumerable<UserContactDto>>;