using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobObjectiveCommands.GetAllJobObjectives;

public sealed record GetAllJobObjectivesCommand : IRequest<IEnumerable<JobObjectiveDto>>;