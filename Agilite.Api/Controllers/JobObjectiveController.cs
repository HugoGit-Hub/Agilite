using Agilite.Api.Messaging.Commands.JobObjectiveCommands.CreateJobObjective;
using Agilite.Api.Messaging.Commands.JobObjectiveCommands.DeleteJobObjective;
using Agilite.Api.Messaging.Commands.JobObjectiveCommands.GetAllJobObjectives;
using Agilite.Api.Messaging.Commands.JobObjectiveCommands.GetJobObjective;
using Agilite.Api.Messaging.Commands.JobObjectiveCommands.UpdateJobObjective;
using Agilite.DataTransferObject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobObjectiveController : ControllerBase
{
    private readonly ISender _sender;

    public JobObjectiveController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(nameof(CreateJobObjective))]
    public async Task<JobObjectiveDto> CreateJobObjective(JobObjectiveDto jobObjective)
        => await _sender.Send(new CreateJobObjectiveCommand(jobObjective));

    [HttpPut(nameof(UpdateJobObjective))]
    public async Task<JobObjectiveDto> UpdateJobObjective(JobObjectiveDto jobObjective)
        => await _sender.Send(new UpdateJobObjectiveCommand(jobObjective));

    [HttpGet(nameof(GetAllJobObjectives))]
    public async Task<IEnumerable<JobObjectiveDto>> GetAllJobObjectives()
        => await _sender.Send(new GetAllJobObjectivesCommand());

    [HttpGet(nameof(GetJobObjective))]
    public async Task<JobObjectiveDto> GetJobObjective(int id)
        => await _sender.Send(new GetJobObjectiveCommand(id));

    [HttpDelete(nameof(DeleteJobObjective))]
    public async Task<JobObjectiveDto> DeleteJobObjective(JobObjectiveDto jobObjective)
        => await _sender.Send(new DeleteJobObjectiveCommand(jobObjective));
}