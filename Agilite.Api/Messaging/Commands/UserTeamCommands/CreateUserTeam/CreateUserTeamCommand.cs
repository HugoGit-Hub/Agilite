using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserTeamCommands.CreateUserTeam;

public sealed record CreateUserTeamCommand(UserTeamDto UserTeam) : IRequest<UserTeamDto>;