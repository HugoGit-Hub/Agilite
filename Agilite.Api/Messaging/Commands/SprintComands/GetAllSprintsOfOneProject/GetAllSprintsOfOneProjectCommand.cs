using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintComands.GetAllSprintsOfOneProject;

public record GetAllSprintsOfOneProjectCommand(int IdProject) : IRequest<IEnumerable<SprintDto>>;