using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserTeamTeamRoleCommands.DeleteUserTeamTeamRole;

public sealed record DeleteUserTeamTeamRoleCommand(UserTeamTeamRoleDto UserTeamTeamRole) : IRequest<UserTeamTeamRoleDto>;