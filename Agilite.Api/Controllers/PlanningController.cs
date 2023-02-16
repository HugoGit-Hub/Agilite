using Agilite.Api.Messaging.Commands.PlanningCommands.CreatePlanning;
using Agilite.Api.Messaging.Commands.PlanningCommands.GetAllPlannings;
using Agilite.Api.Messaging.Commands.PlanningCommands.GetPlanning;
using Agilite.Api.Messaging.Commands.PlanningCommands.UpdatePlanning;
using Agilite.DataTransferObject.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanningController : Controller
{
    private readonly ISender _sender;

    public PlanningController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(nameof(CreatePlanning))]
    public async Task<PlanningDto> CreatePlanning(PlanningDto planning)
        => await _sender.Send(new CreatePlanningCommand(planning));

    [HttpPut(nameof(UpdatePlanning))]
    public async Task<PlanningDto> UpdatePlanning(PlanningDto planning )
        => await _sender.Send(new UpdatePlanningCommand(planning));

    [HttpGet(nameof(GetAllPlannings))]
    public async Task<IEnumerable<PlanningDto>> GetAllPlannings()
        => await _sender.Send(new GetAllPlanningsCommand());

    [HttpGet(nameof(GetPlanning))]
    public async Task<PlanningDto> GetPlanning(int id)
        => await _sender.Send(new GetPlanningCommand(id));

    [HttpDelete(nameof(DeletePlanning))]
    public async Task<PlanningDto> DeletePlanning(PlanningDto planning)
        => await _sender.Send(new UpdatePlanningCommand(planning));
}