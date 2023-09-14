using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobCommands.GetAllJobsOfOneObjective;

public record GetAllJobsOfOneObjectiveCommand(int Id) : IRequest<IEnumerable<JobDto>>;