using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamRoleCommands.DeleteTeamRole;

public sealed record DeleteTeamRoleCommand(TeamRoleDto TeamRole) : IRequest<TeamRoleDto>;