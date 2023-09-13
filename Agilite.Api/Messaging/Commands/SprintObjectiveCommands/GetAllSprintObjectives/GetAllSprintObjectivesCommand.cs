using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintObjectiveCommands.GetAllSprintObjectives;

public sealed record GetAllSprintObjectivesCommand : IRequest<IEnumerable<SprintObjectiveDto>>;