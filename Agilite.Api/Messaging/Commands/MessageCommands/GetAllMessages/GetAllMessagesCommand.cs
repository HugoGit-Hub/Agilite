using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.MessageCommands.GetAllMessages;

public sealed record GetAllMessagesCommand : IRequest<IEnumerable<MessageDto>>;
