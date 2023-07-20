using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserTeamCommands.GetUserTeamByUserId;

public record GetUserTeamByUserIdCommand(int Id) : IRequest<IEnumerable<UserTeamDto>>;