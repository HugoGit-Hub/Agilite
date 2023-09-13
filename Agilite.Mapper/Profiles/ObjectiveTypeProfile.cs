using Agilite.DataTransferObject;
using Agilite.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class ObjectiveTypeProfile : Profile
{
    public ObjectiveTypeProfile()
    {
        CreateMap<ObjectiveType, ObjectiveTypeDto>();
        CreateMap<ObjectiveTypeDto, ObjectiveType>()
            .ForMember(entity => entity.Objectives, member => member.Ignore());
    }
}