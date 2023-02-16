using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserTeamTeamRoleCommands.GetAllUserTeamTeamRoles;

public sealed record GetAllUserTeamTeamRolesCommand : IRequest<IEnumerable<UserTeamTeamRoleDto>>;