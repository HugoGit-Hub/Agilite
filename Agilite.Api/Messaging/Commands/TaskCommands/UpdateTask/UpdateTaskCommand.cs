using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TaskCommands.UpdateTask;

public sealed record UpdateTaskCommand(TaskDto Task) : IRequest<TaskDto>;
