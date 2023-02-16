using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TaskCommands.GetAllTasks;

public sealed record GetAllTasksCommand : IRequest<IEnumerable<TaskDto>>;