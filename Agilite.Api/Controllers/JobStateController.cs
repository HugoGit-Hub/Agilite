using Agilite.Api.Messaging.Commands.JobStateCommands.CreateJobState;
using Agilite.Api.Messaging.Commands.JobStateCommands.DeleteJobState;
using Agilite.Api.Messaging.Commands.JobStateCommands.GetAllJobStates;
using Agilite.Api.Messaging.Commands.JobStateCommands.GetJobState;
using Agilite.Api.Messaging.Commands.JobStateCommands.UpdateJobState;
using Agilite.DataTransferObject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobStateController : ControllerBase
{
    private readonly ISender _sender;

    public JobStateController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(nameof(CreateJobState))]
    public async Task<JobStateDto> CreateJobState(JobStateDto jobState)
        => await _sender.Send(new CreateJobStateCommand(jobState));

    [HttpPut(nameof(UpdateJobState))]
    public async Task<JobStateDto> UpdateJobState(JobStateDto jobState)
        => await _sender.Send(new UpdateJobStateCommand(jobState));

    [HttpGet(nameof(GetAllJobStates))]
    public async Task<IEnumerable<JobStateDto>> GetAllJobStates()
        => await _sender.Send(new GetAllJobStatesCommand());

    [HttpGet(nameof(GetJobState))]
    public async Task<JobStateDto> GetJobState(int id)
        => await _sender.Send(new GetJobStateCommand(id));

    [HttpDelete(nameof(DeleteJobState))]
    public async Task<JobStateDto> DeleteJobState(JobStateDto jobState)
        => await _sender.Send(new DeleteJobStateCommand(jobState));
}