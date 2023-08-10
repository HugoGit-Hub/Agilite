using Agilite.Api.Messaging.Commands.ProjectTypeCommands.GetAllProjectType;
using Agilite.DataTransferObject.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProjectTypeController : ControllerBase
{
    private readonly ISender _sender;

    public ProjectTypeController(ISender sender)
        => _sender = sender;

    [HttpGet(nameof(GetAllProjectType))]
    public async Task<IEnumerable<ProjectTypeDto>> GetAllProjectType(CancellationToken cancellationToken)
        => await _sender.Send(new GetAllProjectTypeCommand(), cancellationToken);
}