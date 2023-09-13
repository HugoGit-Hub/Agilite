using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobCommands.DeleteJob;

public sealed record DeleteJobCommand(JobDto Job) : IRequest<JobDto>;