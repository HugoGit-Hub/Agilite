using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamCommands.GetAllProjectsOfOneTeam;

public record GetAllProjectsOfOneTeamCommand(int IdTeam) : IRequest<IEnumerable<ProjectDto>>;