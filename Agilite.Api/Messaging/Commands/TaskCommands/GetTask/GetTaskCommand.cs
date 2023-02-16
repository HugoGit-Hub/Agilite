using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TaskCommands.GetTask;

public sealed record GetTaskCommand(int id) : IRequest<TaskDto>;