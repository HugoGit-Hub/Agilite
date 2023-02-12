using Agilite.DataTransferObject.DTOs;
using Agilite.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task = Agilite.Entities.Entities.Task;

namespace Agilite.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IService<Task> _service;

    public TaskController(IMapper mapper, IService<Task> service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPost(nameof(CreateTask))]
    public TaskDto CreateTask([FromBody] TaskDto task)
    {
        var entity = _mapper.Map<Task>(task);
        var create = _service.Create(entity);
        return _mapper.Map<TaskDto>(create);
    }

    [HttpPut(nameof(UpdateTask))]
    public TaskDto UpdateTask([FromBody] TaskDto task)
    {
        var entity = _mapper.Map<Task>(task);
        var update = _service.Update(entity);
        return _mapper.Map<TaskDto>(update);
    }

    [HttpGet(nameof(GetAllTasks))]
    public IEnumerable<TaskDto> GetAllTasks()
    {
        var getAll = _service.GetAll();
        var entities = _mapper.Map<IEnumerable<TaskDto>>(getAll);
        return entities;
    }

    [HttpGet(nameof(GetTask))]
    public TaskDto GetTask(int id)
    {
        var getById = _service.GetById(id);
        var entity = _mapper.Map<TaskDto>(getById);
        return entity;
    }

    [HttpDelete(nameof(DeleteTask))]
    public TaskDto DeleteTask([FromBody] TaskDto task)
    {
        var entity = _mapper.Map<Task>(task);
        var delete = _service.Delete(entity);
        return _mapper.Map<TaskDto>(delete);
    }
}