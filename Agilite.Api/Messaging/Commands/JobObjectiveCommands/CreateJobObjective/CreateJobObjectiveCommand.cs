using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobObjectiveCommands.CreateJobObjective;

public sealed record CreateJobObjectiveCommand(JobObjectiveDto JobObjective) : IRequest<JobObjectiveDto>;