using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobStateCommands.GetAllJobStates;

public sealed record GetAllJobStatesCommand : IRequest<IEnumerable<JobStateDto>>;