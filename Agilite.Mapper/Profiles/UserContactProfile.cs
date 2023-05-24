using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class UserContactProfile : Profile
{
    public UserContactProfile()
    {
        CreateMap<UserContact, UserContactDto>();
        CreateMap<UserContactDto, UserContact>()
            .ForMember(entity => entity.IdContactNavigation, member => member.Ignore())
            .ForMember(entity => entity.IdUserNavigation, member => member.Ignore());
    }
}