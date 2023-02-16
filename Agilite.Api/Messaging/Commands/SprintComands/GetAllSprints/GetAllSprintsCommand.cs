using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintComands.GetAllSprints;

public sealed record GetAllSprintsCommand : IRequest<IEnumerable<SprintDto>>;