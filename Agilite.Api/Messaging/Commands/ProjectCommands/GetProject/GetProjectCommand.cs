using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ProjectCommands.GetProject;

public sealed record GetProjectCommand(int id) : IRequest<ProjectDto>;