using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamCommands.GetAllTeams;

public sealed record GetAllTeamsCommand : IRequest<IEnumerable<TeamDto>>;