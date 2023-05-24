using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserTeamCommands.UpdateUserTeam;

public sealed record UpdateUserTeamCommand(UserTeamDto UserTeam) : IRequest<UserTeamDto>;