using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveTypeCommands.UpdateObjectiveType;

public sealed record UpdateObjectiveTypeCommand(ObjectiveTypeDto ObjectiveType) : IRequest<ObjectiveTypeDto>;