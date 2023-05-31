using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintObjectiveCommands.GetSprintObjective;

public sealed record GetSprintObjectiveCommand(int Id) : IRequest<SprintObjectiveDto>;