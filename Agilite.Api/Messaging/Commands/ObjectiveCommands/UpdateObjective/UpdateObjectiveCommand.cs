using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveCommands.UpdateObjective;

public sealed record UpdateObjectiveCommand(ObjectiveDto Objective) : IRequest<ObjectiveDto>;