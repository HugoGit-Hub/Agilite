using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamCommands.CreateTeam;

public sealed record CreateTeamCommand(TeamDto Team) : IRequest<TeamDto>;