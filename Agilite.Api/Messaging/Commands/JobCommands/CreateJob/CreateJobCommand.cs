using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobCommands.CreateJob;

public sealed record CreateJobCommand(JobDto Job) : IRequest<JobDto>;