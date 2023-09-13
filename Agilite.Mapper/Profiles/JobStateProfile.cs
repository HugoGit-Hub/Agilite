using Agilite.DataTransferObject;
using Agilite.Entities;
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