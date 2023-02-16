using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ProjectCommands.DeleteProject;

public sealed record DeleteProjectCommand(ProjectDto Project) : IRequest<ProjectDto>;