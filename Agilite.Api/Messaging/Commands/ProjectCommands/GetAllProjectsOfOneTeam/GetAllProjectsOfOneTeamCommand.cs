using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ProjectCommands.GetAllProjectsOfOneTeam;

public record GetAllProjectsOfOneTeamCommand(int IdTeam) : IRequest<IEnumerable<ProjectDto>>;