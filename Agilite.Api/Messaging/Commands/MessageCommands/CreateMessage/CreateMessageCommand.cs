using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.MessageCommands.CreateMessage;

public sealed record CreateMessageCommand(MessageDto Message) : IRequest<MessageDto>;