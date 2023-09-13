using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.MessageCommands.GetMessage;

public sealed record GetMessageCommand(int id) : IRequest<MessageDto>;