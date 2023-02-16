using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamRoleCommands.UpdateTeamRole;

public sealed record UpdateTeamRoleCommand(TeamRoleDto TeamRole) : IRequest<TeamRoleDto>;