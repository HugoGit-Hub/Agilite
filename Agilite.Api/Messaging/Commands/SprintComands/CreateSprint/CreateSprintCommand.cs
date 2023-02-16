using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintComands.CreateSprint;

public sealed record CreateSprintCommand(SprintDto Sprint) : IRequest<SprintDto>;