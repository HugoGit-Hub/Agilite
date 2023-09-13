using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobCommands.UpdateJob;

public sealed record UpdateJobCommand(JobDto Job) : IRequest<JobDto>;
