using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintComands.GetSprint;

public sealed record GetSprintCommand(int id) : IRequest<SprintDto>;