using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class JobStateProfile : Profile
{
    public JobStateProfile()
    {
        CreateMap<JobState, JobStateDto>();
        CreateMap<JobStateDto, JobState>()
            .ForMember(entity => entity.Jobs, member => member.Ignore());
    }
}