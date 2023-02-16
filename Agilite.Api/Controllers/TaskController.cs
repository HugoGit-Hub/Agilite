using Agilite.Api.Messaging.Commands.TaskCommands.CreateTaskCommand;
using Agilite.Api.Messaging.Commands.TaskCommands.DeleteTask;
using Agilite.Api.Messaging.Commands.TaskCommands.GetAllTasks;
using Agilite.Api.Messaging.Commands.TaskCommands.GetTask;
using Agilite.Api.Messaging.Commands.TaskCommands.UpdateTask;
using Agilite.DataTransferObject.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ISender _sender;

    public TaskController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(nameof(CreateTask))]
    public async Task<TaskDto> CreateTask(TaskDto task)
        => await _sender.Send(new CreateTaskCommand(task));

    [HttpPut(nameof(UpdateTask))]
    public async Task<TaskDto> UpdateTask([FromBody] TaskDto task)
        => await _sender.Send(new UpdateTaskCommand(task));

    [HttpGet(nameof(GetAllTasks))]
    public async Task<IEnumerable<TaskDto>> GetAllTasks()
        => await _sender.Send(new GetAllTasksCommand());

    [HttpGet(nameof(GetTask))]
    public async Task<TaskDto> GetTask(int id)
        => await _sender.Send(new GetTaskCommand(id));

    [HttpDelete(nameof(DeleteTask))]
    public async Task<TaskDto> DeleteTask(TaskDto task)
        => await _sender.Send(new DeleteTaskCommand(task));
}