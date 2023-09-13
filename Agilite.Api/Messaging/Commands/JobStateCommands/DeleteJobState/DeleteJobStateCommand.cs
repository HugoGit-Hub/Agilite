using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobStateCommands.DeleteJobState;

public sealed record DeleteJobStateCommand(JobStateDto JobState) : IRequest<JobStateDto>;