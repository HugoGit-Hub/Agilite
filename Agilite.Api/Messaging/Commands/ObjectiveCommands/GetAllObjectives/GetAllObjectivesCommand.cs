using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveCommands.GetAllObjectives;

public sealed record GetAllObjectivesCommand : IRequest<IEnumerable<ObjectiveDto>>;