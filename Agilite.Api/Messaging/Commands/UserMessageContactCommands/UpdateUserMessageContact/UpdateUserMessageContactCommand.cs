using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserMessageContactCommands.UpdateUserMessageContact;

public sealed record UpdateUserMessageContactCommand(UserMessageContact UserMessageContact) : IRequest<UserMessageContactDto>;