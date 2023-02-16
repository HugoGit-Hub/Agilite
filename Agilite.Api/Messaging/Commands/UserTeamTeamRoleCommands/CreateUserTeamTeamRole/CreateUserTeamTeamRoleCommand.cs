using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserTeamTeamRoleCommands.CreateUserTeamTeamRole;

public sealed record CreateUserTeamTeamRoleCommand(UserTeamTeamRoleDto UserTeamTeamRole) : IRequest<UserTeamTeamRoleDto>;