using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobObjectiveCommands.DeleteJobObjective;

public sealed record DeleteJobObjectiveCommand(JobObjectiveDto JobObjective) : IRequest<JobObjectiveDto>;