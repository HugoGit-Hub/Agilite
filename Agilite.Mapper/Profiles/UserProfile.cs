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
            .ForMember(entity => entity.SaltUser, member => member.Ignore())
            .ForMember(entity => entity.Messages, member => member.Ignore())
            .ForMember(entity => entity.UserTeams, member => member.Ignore());
    }
}