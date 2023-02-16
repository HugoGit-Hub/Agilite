using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ProjectCommands.UpdateProject;

public sealed record UpdateProjectCommand(ProjectDto Project) : IRequest<ProjectDto>;