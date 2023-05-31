using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobStateCommands.GetJobState;

public sealed record GetJobStateCommand(int Id) : IRequest<JobStateDto>;