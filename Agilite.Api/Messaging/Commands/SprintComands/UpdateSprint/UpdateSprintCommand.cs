using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintComands.UpdateSprint;

public sealed record UpdateSprintCommand(SprintDto Sprint) : IRequest<SprintDto>;