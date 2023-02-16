using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveCommands.DeleteObjective;

public sealed record DeleteObjectiveCommand(ObjectiveDto Objective) : IRequest<ObjectiveDto>;