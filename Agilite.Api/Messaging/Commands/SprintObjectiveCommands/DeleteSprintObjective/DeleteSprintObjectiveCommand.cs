using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintObjectiveCommands.DeleteSprintObjective;

public sealed record DeleteSprintObjectiveCommand(SprintObjectiveDto SprintObjective) : IRequest<SprintObjectiveDto>;