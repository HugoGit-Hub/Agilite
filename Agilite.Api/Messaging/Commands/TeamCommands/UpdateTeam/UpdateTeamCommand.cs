using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamCommands.UpdateTeam;

public sealed record UpdateTeamCommand(TeamDto Team) : IRequest<TeamDto>;