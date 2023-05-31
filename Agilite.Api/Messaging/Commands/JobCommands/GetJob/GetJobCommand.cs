using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobCommands.GetJob;

public sealed record GetJobCommand(int Id) : IRequest<JobDto>;