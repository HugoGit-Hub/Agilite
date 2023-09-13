using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.MessageCommands.UpdateMessage;

public sealed record UpdateMessageCommand(MessageDto Message) : IRequest<MessageDto>;