using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using AutoMapper;

namespace Agilite.UI.Mapper.Profiles;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<JobDto, TaskModel>();
        CreateMap<TaskModel, JobDto>();
    }
}