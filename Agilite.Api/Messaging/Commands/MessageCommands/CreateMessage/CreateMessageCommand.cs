using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.MessageCommands.CreateMessage;

public sealed record CreateMessageCommand(MessageDto Message) : IRequest<MessageDto>;