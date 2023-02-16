using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamCommands.DeleteTeam;

public sealed record DeleteTeamCommand(TeamDto Team) : IRequest<TeamDto>;