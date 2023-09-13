using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveTypeCommands.GetObjectiveType;

public sealed record GetObjectiveTypeCommand(int Id) : IRequest<ObjectiveTypeDto>;