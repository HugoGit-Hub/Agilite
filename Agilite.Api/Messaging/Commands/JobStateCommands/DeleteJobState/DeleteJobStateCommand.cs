using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobStateCommands.DeleteJobState;

public sealed record DeleteJobStateCommand(JobStateDto JobState) : IRequest<JobStateDto>;