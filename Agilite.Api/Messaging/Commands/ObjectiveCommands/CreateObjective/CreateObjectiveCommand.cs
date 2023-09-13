using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveCommands.CreateObjective;

public sealed record CreateObjectiveCommand(ObjectiveDto Objective) : IRequest<ObjectiveDto>;