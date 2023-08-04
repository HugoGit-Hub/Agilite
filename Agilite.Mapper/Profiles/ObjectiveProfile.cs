using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class ObjectiveProfile : Profile
{
    public ObjectiveProfile()
    {
        CreateMap<Objective, ObjectiveDto>();
        CreateMap<ObjectiveDto, Objective>()
            .ForMember(entity => entity.IdObjectiveTypeNavigation, member => member.Ignore())
            .ForMember(entity => entity.JobObjectives, member => member.Ignore());
    }
}