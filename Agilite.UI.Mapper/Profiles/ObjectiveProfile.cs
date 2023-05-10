using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using AutoMapper;

namespace Agilite.UI.Mapper.Profiles;

public class ObjectiveProfile : Profile
{
    public ObjectiveProfile()
    {
        CreateMap<ObjectiveDto, ObjectiveModel>();
        CreateMap<ObjectiveModel, ObjectiveDto>();
    }
}