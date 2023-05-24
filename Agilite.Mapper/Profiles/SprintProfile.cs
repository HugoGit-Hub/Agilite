using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class SprintProfile : Profile
{
    public SprintProfile()
    {
        CreateMap<Sprint, SprintDto>();
        CreateMap<SprintDto, Sprint>()
            .ForMember(entity => entity.IdProjectNavigation, member => member.Ignore())
            .ForMember(entity => entity.SprintObjectives, member => member.Ignore());
    }
}