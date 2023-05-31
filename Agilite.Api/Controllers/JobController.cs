using Agilite.Api.Messaging.Commands.JobCommands.CreateJob;
using Agilite.Api.Messaging.Commands.JobCommands.DeleteJob;
using Agilite.Api.Messaging.Commands.JobCommands.GetAllJobs;
using Agilite.Api.Messaging.Commands.JobCommands.GetJob;
using Agilite.Api.Messaging.Commands.JobCommands.UpdateJob;
using Agilite.DataTransferObject.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobController : ControllerBase
{
    private readonly ISender _sender;

    public JobController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(nameof(CreateTask))]
    public async Task<JobDto> CreateTask(JobDto job)
        => await _sender.Send(new CreateJobCommand(job));

    [HttpPut(nameof(UpdateTask))]
    public async Task<JobDto> UpdateTask([FromBody] JobDto job)
        => await _sender.Send(new UpdateJobCommand(job));

    [HttpGet(nameof(GetAllTasks))]
    public async Task<IEnumerable<JobDto>> GetAllTasks()
        => await _sender.Send(new GetAllJobsCommand());

    [HttpGet(nameof(GetTask))]
    public async Task<JobDto> GetTask(int id)
        => await _sender.Send(new GetJobCommand(id));

    [HttpDelete(nameof(DeleteTask))]
    public async Task<JobDto> DeleteTask(JobDto job)
        => await _sender.Send(new DeleteJobCommand(job));
}