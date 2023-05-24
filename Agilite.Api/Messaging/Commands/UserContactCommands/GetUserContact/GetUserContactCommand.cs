using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserContactCommands.GetUserContact;

public sealed record GetUserContactCommand(int Id) : IRequest<UserContactDto>;