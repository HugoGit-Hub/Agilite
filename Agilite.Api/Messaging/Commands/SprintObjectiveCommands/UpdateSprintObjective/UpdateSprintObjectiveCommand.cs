using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintObjectiveCommands.UpdateSprintObjective;

public sealed record UpdateSprintObjectiveCommand(SprintObjectiveDto SprintObjective) : IRequest<SprintObjectiveDto>;