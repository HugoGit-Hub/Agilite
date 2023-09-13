using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ProjectCommands.GetAllProjects;

public sealed record GetAllProjectsCommand : IRequest<IEnumerable<ProjectDto>>;