using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserMessageContactCommands.GetAllUserMessageContacts;

public sealed record GetAllUserMessageContactsCommand : IRequest<IEnumerable<UserMessageContactDto>>;