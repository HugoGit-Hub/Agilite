using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamCommands.GetAllTeams;

public sealed record GetAllTeamsCommand : IRequest<IEnumerable<TeamDto>>;