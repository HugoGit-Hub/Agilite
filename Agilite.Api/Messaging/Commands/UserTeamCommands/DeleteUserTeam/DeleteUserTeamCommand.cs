using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserTeamCommands.DeleteUserTeam;

public sealed record DeleteUserTeamCommand(UserTeamDto UserTeam) : IRequest<UserTeamDto>;