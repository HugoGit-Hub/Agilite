using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamRoleCommands.GetAllTeamRoles;

public sealed record GetAllTeamRolesCommand : IRequest<IEnumerable<TeamRoleDto>>;