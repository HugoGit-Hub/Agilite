using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobStateCommands.UpdateJobState;

public sealed record UpdateJobStateCommand(JobStateDto JobState) : IRequest<JobStateDto>;