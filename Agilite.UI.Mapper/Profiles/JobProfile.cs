using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using AutoMapper;

namespace Agilite.UI.Mapper.Profiles;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<JobDto, JobModel>();
        CreateMap<JobModel, JobDto>();
    }
}