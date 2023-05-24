using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobStateCommands.GetAllJobStates;

public sealed record GetAllJobStatesCommand : IRequest<IEnumerable<JobStateDto>>;