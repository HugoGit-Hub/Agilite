using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobObjectiveCommands.GetAllJobObjectives;

public sealed record GetAllJobObjectivesCommand : IRequest<IEnumerable<JobObjectiveDto>>;