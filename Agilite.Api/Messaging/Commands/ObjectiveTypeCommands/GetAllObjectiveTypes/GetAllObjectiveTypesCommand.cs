using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveTypeCommands.GetAllObjectiveTypes;

public sealed record GetAllObjectiveTypesCommand : IRequest<IEnumerable<ObjectiveTypeDto>>;