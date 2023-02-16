using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamRoleCommands.CreateTeamRole;

public sealed record CreateTeamRoleCommand(TeamRoleDto TeamRole) : IRequest<TeamRoleDto>;