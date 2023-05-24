using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobObjectiveCommands.UpdateJobObjective;

public sealed record UpdateJobObjectiveCommand(JobObjectiveDto JobObjective) : IRequest<JobObjectiveDto>;