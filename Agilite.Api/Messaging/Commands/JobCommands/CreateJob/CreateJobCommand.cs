using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobCommands.CreateJob;

public sealed record CreateJobCommand(JobDto Job) : IRequest<JobDto>;