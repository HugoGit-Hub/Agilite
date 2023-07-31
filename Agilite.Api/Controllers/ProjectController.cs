using Agilite.Api.Messaging.Commands.ProjectCommands.CreateProject;
using Agilite.Api.Messaging.Commands.ProjectCommands.DeleteProject;
using Agilite.Api.Messaging.Commands.ProjectCommands.GetAllProjects;
using Agilite.Api.Messaging.Commands.ProjectCommands.GetAllProjectsOfOneTeam;
using Agilite.Api.Messaging.Commands.ProjectCommands.GetProject;
using Agilite.DataTransferObject.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly ISender _sender;

    public ProjectController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(nameof(CreateProject))]
    public async Task<ProjectDto> CreateProject(ProjectDto project)
        => await _sender.Send(new CreateProjectCommand(project));

    [HttpPut(nameof(UpdateProject))]
    public async Task<ProjectDto> UpdateProject(ProjectDto project)
        => await _sender.Send(new CreateProjectCommand(project));

    [HttpGet(nameof(GetAllProjects))]
    public async Task<IEnumerable<ProjectDto>> GetAllProjects()
        => await _sender.Send(new GetAllProjectsCommand());

    [HttpGet(nameof(GetAllProjectsOfOneTeam))]
    public async Task<IEnumerable<ProjectDto>> GetAllProjectsOfOneTeam(int idTeam, CancellationToken cancellationToken)
        => await _sender.Send(new GetAllProjectsOfOneTeamCommand(idTeam), cancellationToken);

    [HttpGet(nameof(GetProject))]
    public async Task<ProjectDto> GetProject(int id)
        => await _sender.Send(new GetProjectCommand(id));

    [HttpDelete(nameof(DeleteProject))]
    public async Task<ProjectDto> DeleteProject(ProjectDto project)
        => await _sender.Send(new DeleteProjectCommand(project));
}