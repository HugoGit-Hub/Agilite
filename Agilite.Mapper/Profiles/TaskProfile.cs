using Agilite.DataTransferObject.DTOs;
using AutoMapper;
using Task = Agilite.Entities.Entities.Task;

namespace Agilite.Mapper.Profiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<Task, TaskDto>();
        CreateMap<TaskDto, Task>()
            .ForMember(entity => entity.ObjectiveIdObjectiveNavigation, member => member.Ignore());
    }
}