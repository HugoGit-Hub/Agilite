using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<Job, JobDto>();
        CreateMap<JobDto, Job>()
            .ForMember(entity => entity.IdJobStateNavigation, member => member.Ignore());
    }
}