using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>()
            .ForMember(entity => entity.UserMessageContacts, member => member.Ignore())
            .ForMember(entity => entity.Plannings, member => member.Ignore())
            .ForMember(entity => entity.UserTeamTeamRoles, member => member.Ignore());
    }
}