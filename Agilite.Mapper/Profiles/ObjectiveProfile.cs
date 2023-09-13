using Agilite.DataTransferObject;
using Agilite.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class ObjectiveProfile : Profile
{
    public ObjectiveProfile()
    {
        CreateMap<Objective, ObjectiveDto>();
        CreateMap<ObjectiveDto, Objective>();
    }
}