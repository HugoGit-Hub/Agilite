using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.PlanningCommands.GetPlanning;

public sealed record GetPlanningCommand(int id) : IRequest<PlanningDto>;