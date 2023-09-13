using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.MessageCommands.DeleteMessage;

public sealed record DeleteMessageCommand(MessageDto message) : IRequest<MessageDto>;
