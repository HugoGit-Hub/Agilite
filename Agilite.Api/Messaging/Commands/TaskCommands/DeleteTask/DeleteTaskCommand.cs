using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TaskCommands.DeleteTask;

public sealed record DeleteTaskCommand(TaskDto Task) : IRequest<TaskDto>;