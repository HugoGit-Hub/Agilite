using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.PlanningCommands.DeletePlanning;

public sealed record DeletePlanningCommand(PlanningDto Planning) : IRequest<PlanningDto>;