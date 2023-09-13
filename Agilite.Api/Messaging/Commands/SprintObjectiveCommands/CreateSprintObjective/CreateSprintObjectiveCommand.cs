using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintObjectiveCommands.CreateSprintObjective;

public sealed record CreateSprintObjectiveCommand(SprintObjectiveDto SprintObjective) : IRequest<SprintObjectiveDto>;