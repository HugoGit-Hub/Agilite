using Agilite.Api.Messaging.Commands.SprintComands.CreateSprint;
using Agilite.Api.Messaging.Commands.SprintComands.DeleteSprint;
using Agilite.Api.Messaging.Commands.SprintComands.GetAllSprints;
using Agilite.Api.Messaging.Commands.SprintComands.GetAllSprintsOfOneProject;
using Agilite.Api.Messaging.Commands.SprintComands.GetSprint;
using Agilite.Api.Messaging.Commands.SprintComands.UpdateSprint;
using Agilite.DataTransferObject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SprintController : ControllerBase
{
    private readonly ISender _sender;

    public SprintController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(nameof(Create))]
    public async Task<SprintDto> Create(SprintDto sprint)
        => await _sender.Send(new CreateSprintCommand(sprint));

    [HttpPut(nameof(UpdateSprint))]
    public async Task<SprintDto> UpdateSprint(SprintDto sprint)
        => await _sender.Send(new UpdateSprintCommand(sprint));

    [HttpGet(nameof(GetAllSprints))]
    public async Task<IEnumerable<SprintDto>> GetAllSprints()
        => await _sender.Send(new GetAllSprintsCommand());

    [HttpGet(nameof(GetAllSprintsOfOneProject))]
    public async Task<IEnumerable<SprintDto>> GetAllSprintsOfOneProject(int idProject, CancellationToken cancellationToken)
        => await _sender.Send(new GetAllSprintsOfOneProjectCommand(idProject), cancellationToken);

    [HttpGet(nameof(Get))]
    public async Task<SprintDto> Get(int id)
        => await _sender.Send(new GetSprintCommand(id));

    [HttpDelete(nameof(DeleteSprint))]
    public async Task<SprintDto> DeleteSprint([FromBody] SprintDto sprint)
        => await _sender.Send(new DeleteSprintCommand(sprint));
}