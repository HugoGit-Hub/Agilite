using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobStateCommands.CreateJobState;

public sealed record CreateJobStateCommand(JobStateDto JobState) : IRequest<JobStateDto>;