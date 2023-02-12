using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class PlanningProfile : Profile
{
    public PlanningProfile()
    {
        CreateMap<Planning, PlanningDto>();
        CreateMap<PlanningDto, Planning>()
            .ForMember(entity => entity.UserIdUserNavigation, member => member.Ignore());
    }
}