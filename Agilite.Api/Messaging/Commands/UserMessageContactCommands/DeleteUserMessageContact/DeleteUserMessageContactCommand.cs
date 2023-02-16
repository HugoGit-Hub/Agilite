using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserMessageContactCommands.DeleteUserMessageContact;

public sealed record DeleteUserMessageContactCommand(UserMessageContactDto UserMessageContact) : IRequest<UserMessageContactDto>;