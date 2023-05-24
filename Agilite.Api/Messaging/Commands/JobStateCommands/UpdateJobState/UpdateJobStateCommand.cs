using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobStateCommands.UpdateJobState;

public sealed record UpdateJobStateCommand(JobStateDto JobState) : IRequest<JobStateDto>;