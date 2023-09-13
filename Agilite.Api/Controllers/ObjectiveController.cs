using Agilite.Api.Messaging.Commands.ObjectiveCommands.CreateObjective;
using Agilite.Api.Messaging.Commands.ObjectiveCommands.DeleteObjective;
using Agilite.Api.Messaging.Commands.ObjectiveCommands.GetAllObjectives;
using Agilite.Api.Messaging.Commands.ObjectiveCommands.GetAllObjectivesOfOneSprint;
using Agilite.Api.Messaging.Commands.ObjectiveCommands.GetObjective;
using Agilite.Api.Messaging.Commands.ObjectiveCommands.UpdateObjective;
using Agilite.DataTransferObject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ObjectiveController : ControllerBase
{
    private readonly ISender _sender;

    public ObjectiveController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(nameof(CreateObjective))]
    public async Task<ObjectiveDto> CreateObjective(ObjectiveDto objective)
        => await _sender.Send(new CreateObjectiveCommand(objective));

    [HttpPut(nameof(UpdateObjective))]
    public async Task<ObjectiveDto> UpdateObjective(ObjectiveDto objective)
        => await _sender.Send(new UpdateObjectiveCommand(objective));

    [HttpGet(nameof(GetAllObjectives))]
    public async Task<IEnumerable<ObjectiveDto>> GetAllObjectives()
        => await _sender.Send(new GetAllObjectivesCommand());

    [HttpGet(nameof(GetAllObjectivesOfOneSprint))]
    public async Task<IEnumerable<ObjectiveDto>> GetAllObjectivesOfOneSprint(int sprintId, CancellationToken cancellationToken)
        => await _sender.Send(new GetAllObjectivesOfOneSprintCommand(sprintId), cancellationToken);

    [HttpGet(nameof(GetObjective))]
    public async Task<ObjectiveDto> GetObjective(int id)
        => await _sender.Send(new GetObjectiveCommand(id));

    [HttpDelete(nameof(DeleteObjective))]
    public async Task<ObjectiveDto> DeleteObjective(ObjectiveDto objective)
        => await _sender.Send(new DeleteObjectiveCommand(objective));
}