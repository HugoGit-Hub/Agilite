using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserTeamTeamRoleCommands.UpdateUserTeamTeamRole;

public sealed record UpdateUserTeamTeamRoleCommand(UserTeamTeamRoleDto UserTeamTeamRole) : IRequest<UserTeamTeamRoleDto>;