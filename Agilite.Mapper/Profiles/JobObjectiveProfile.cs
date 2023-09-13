using Agilite.DataTransferObject;
using Agilite.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class JobObjectiveProfile : Profile
{
    public JobObjectiveProfile()
    {
        CreateMap<JobObjective, JobObjectiveDto>();
        CreateMap<JobObjectiveDto, JobObjective>()
            .ForMember(entity => entity.IdJobNavigation, member => member.Ignore())
            .ForMember(entity => entity.IdObjectiveNavigation, member => member.Ignore());
    }
}