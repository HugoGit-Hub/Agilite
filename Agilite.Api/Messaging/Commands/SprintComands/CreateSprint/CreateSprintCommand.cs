using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintComands.CreateSprint;

public sealed record CreateSprintCommand(SprintDto Sprint) : IRequest<SprintDto>;