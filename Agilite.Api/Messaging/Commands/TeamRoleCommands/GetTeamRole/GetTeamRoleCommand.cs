using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamRoleCommands.GetTeamRole;

public sealed record GetTeamRoleCommand(int id) : IRequest<TeamRoleDto>;