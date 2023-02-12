using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IService<Project> _service;

    public ProjectController(IMapper mapper, IService<Project> service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPost(nameof(CreateProject))]
    public ProjectDto CreateProject([FromBody] ProjectDto project)
    {
        var entity = _mapper.Map<Project>(project);
        var create = _service.Create(entity);
        return _mapper.Map<ProjectDto>(create);
    }

    [HttpPut(nameof(UpdateProject))]
    public ProjectDto UpdateProject([FromBody] ProjectDto project)
    {
        var entity = _mapper.Map<Project>(project);
        var update = _service.Update(entity);
        return _mapper.Map<ProjectDto>(update);
    }

    [HttpGet(nameof(GetAllProjects))]
    public IEnumerable<ProjectDto> GetAllProjects()
    {
        var getAll = _service.GetAll();
        var entities = _mapper.Map<IEnumerable<ProjectDto>>(getAll);
        return entities;
    }

    [HttpGet(nameof(GetProject))]
    public ProjectDto GetProject(int id)
    {
        var getById = _service.GetById(id);
        var entity = _mapper.Map<ProjectDto>(getById);
        return entity;
    }

    [HttpDelete(nameof(DeleteProject))]
    public ProjectDto DeleteProject([FromBody] ProjectDto project)
    {
        var entity = _mapper.Map<Project>(project);
        var delete = _service.Delete(entity);
        return _mapper.Map<ProjectDto>(delete);
    }
}