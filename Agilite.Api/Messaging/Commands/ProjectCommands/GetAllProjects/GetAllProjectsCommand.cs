using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ProjectCommands.GetAllProjects;

public sealed record GetAllProjectsCommand : IRequest<IEnumerable<ProjectDto>>;