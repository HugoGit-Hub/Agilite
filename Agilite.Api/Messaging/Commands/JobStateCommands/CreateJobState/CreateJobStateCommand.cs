using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobStateCommands.CreateJobState;

public sealed record CreateJobStateCommand(JobStateDto JobState) : IRequest<JobStateDto>;