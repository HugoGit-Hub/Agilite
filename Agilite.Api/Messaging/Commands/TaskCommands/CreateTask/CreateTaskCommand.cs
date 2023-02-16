using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TaskCommands.CreateTaskCommand;

public sealed record CreateTaskCommand(TaskDto Task) : IRequest<TaskDto>;