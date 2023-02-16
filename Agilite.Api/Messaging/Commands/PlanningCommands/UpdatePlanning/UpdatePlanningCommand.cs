using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.PlanningCommands.UpdatePlanning;

public sealed record UpdatePlanningCommand(PlanningDto Planning) : IRequest<PlanningDto>;