using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintObjectiveCommands.UpdateSprintObjective;

public sealed record UpdateSprintObjectiveCommand(SprintObjectiveDto SprintObjective) : IRequest<SprintObjectiveDto>;