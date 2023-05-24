using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveTypeCommands.DeleteObjectiveType;

public sealed record DeleteObjectiveTypeCommand(ObjectiveTypeDto ObjectiveType) : IRequest<ObjectiveTypeDto>;