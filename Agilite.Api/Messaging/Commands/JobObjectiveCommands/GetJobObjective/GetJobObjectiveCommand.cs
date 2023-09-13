using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobObjectiveCommands.GetJobObjective;

public sealed record GetJobObjectiveCommand(int Id) : IRequest<JobObjectiveDto>;