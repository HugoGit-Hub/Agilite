using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class UserMessageContactProfile : Profile
{
    public UserMessageContactProfile()
    {
        CreateMap<UserMessageContact, UserMessageContactDto>();
        CreateMap<UserMessageContactDto, UserMessageContact>()
        .ForMember(entity => entity.ContactIdContactNavigation, member => member.Ignore())
        .ForMember(entity => entity.MessageIdMessageNavigation, member => member.Ignore())
        .ForMember(entity => entity.UserIdUserNavigation, member => member.Ignore());
    }
}