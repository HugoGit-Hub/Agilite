using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveCommands.GetObjective;

public sealed record GetObjectiveCommand(int id) : IRequest<ObjectiveDto>;