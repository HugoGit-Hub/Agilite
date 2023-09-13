using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ProjectCommands.DeleteProject;

public sealed record DeleteProjectCommand(ProjectDto Project) : IRequest<ProjectDto>;