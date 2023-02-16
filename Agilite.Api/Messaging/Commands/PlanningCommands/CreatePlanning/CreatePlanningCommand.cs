using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.PlanningCommands.CreatePlanning;

public sealed record CreatePlanningCommand(PlanningDto Planning) : IRequest<PlanningDto>; 