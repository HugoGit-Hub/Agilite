using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserMessageContactCommands.CreateUserMessageContact;

public sealed record CreateUserMessageContactCommand(UserMessageContactDto UserMessageContact) : IRequest<UserMessageContactDto>;