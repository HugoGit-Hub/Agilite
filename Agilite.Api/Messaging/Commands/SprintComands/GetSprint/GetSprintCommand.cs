using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintComands.GetSprint;

public sealed record GetSprintCommand(int id) : IRequest<SprintDto>;