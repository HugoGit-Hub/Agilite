using Agilite.DataTransferObject;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveCommands.GetAllObjectivesOfOneSprint;

public record GetAllObjectivesOfOneSprintCommand(int IdSprint) : IRequest<IEnumerable<ObjectiveDto>>;