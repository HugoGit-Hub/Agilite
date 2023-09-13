using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveCommands.GetAllObjectives;

public sealed record GetAllObjectivesCommand : IRequest<IEnumerable<ObjectiveDto>>;