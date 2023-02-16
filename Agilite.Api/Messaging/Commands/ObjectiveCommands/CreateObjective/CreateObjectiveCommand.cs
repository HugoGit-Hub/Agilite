using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveCommands.CreateObjective;

public sealed record CreateObjectiveCommand(ObjectiveDto Objective) : IRequest<ObjectiveDto>;