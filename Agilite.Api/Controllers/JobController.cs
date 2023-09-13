using Agilite.Api.Messaging.Commands.JobCommands.CreateJob;
using Agilite.Api.Messaging.Commands.JobCommands.DeleteJob;
using Agilite.Api.Messaging.Commands.JobCommands.GetAllJobs;
using Agilite.Api.Messaging.Commands.JobCommands.GetAllJobsOfOneObjective;
using Agilite.Api.Messaging.Commands.JobCommands.GetJob;
using Agilite.Api.Messaging.Commands.JobCommands.UpdateJob;
using Agilite.DataTransferObject;
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

    [HttpPost(nameof(CreateJob))]
    public async Task<JobDto> CreateJob(JobDto job)
        => await _sender.Send(new CreateJobCommand(job));

    [HttpPut(nameof(UpdateJob))]
    public async Task<JobDto> UpdateJob([FromBody] JobDto job)
        => await _sender.Send(new UpdateJobCommand(job));

    [HttpGet(nameof(GetAllJobs))]
    public async Task<IEnumerable<JobDto>> GetAllJobs()
        => await _sender.Send(new GetAllJobsCommand());

    [HttpGet(nameof(GetAllJobsOfOneObjective))]
    public async Task<IEnumerable<JobDto>> GetAllJobsOfOneObjective(int id, CancellationToken cancellationToken)
        => await _sender.Send(new GetAllJobsOfOneObjectiveCommand(id), cancellationToken);

    [HttpGet(nameof(GetJob))]
    public async Task<JobDto> GetJob(int id)
        => await _sender.Send(new GetJobCommand(id));

    [HttpDelete(nameof(DeleteJob))]
    public async Task<JobDto> DeleteJob(JobDto job)
        => await _sender.Send(new DeleteJobCommand(job));
}