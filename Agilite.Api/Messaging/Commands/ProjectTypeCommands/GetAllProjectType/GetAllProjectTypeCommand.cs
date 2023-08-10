using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ProjectTypeCommands.GetAllProjectType;

public record GetAllProjectTypeCommand : IRequest<IEnumerable<ProjectTypeDto>>;