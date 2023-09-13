using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ProjectCommands.CreateProject;

public sealed record CreateProjectCommand(ProjectDto Dto) : IRequest<ProjectDto>;