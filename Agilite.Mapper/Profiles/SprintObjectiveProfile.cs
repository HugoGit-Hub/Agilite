using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class SprintObjectiveProfile : Profile
{
    public SprintObjectiveProfile()
    {
        CreateMap<SprintObjective, SprintObjectiveProfile>();
        CreateMap<SprintObjectiveProfile, SprintObjective>()
            .ForMember(entity => entity.IdObjectiveNavigation, member => member.Ignore())
            .ForMember(entity => entity.IdSprintNavigation, member => member.Ignore());
    }
}