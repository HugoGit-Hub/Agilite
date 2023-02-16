using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.PlanningCommands.GetAllPlannings;

public sealed record GetAllPlanningsCommand : IRequest<IEnumerable<PlanningDto>>;