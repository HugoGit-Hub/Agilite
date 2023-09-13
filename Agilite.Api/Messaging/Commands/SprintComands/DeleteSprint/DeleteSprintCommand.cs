using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintComands.DeleteSprint;

public sealed record DeleteSprintCommand(SprintDto Sprint) : IRequest<SprintDto>;