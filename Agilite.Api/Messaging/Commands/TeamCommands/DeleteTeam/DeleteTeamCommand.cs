using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamCommands.DeleteTeam;

public sealed record DeleteTeamCommand(int Id) : IRequest<TeamDto>;