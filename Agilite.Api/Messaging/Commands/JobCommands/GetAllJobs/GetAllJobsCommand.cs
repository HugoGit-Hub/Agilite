using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobCommands.GetAllJobs;

public sealed record GetAllJobsCommand : IRequest<IEnumerable<JobDto>>;