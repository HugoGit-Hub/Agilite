using Agilite.DataTransferObject;
using Agilite.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>()
            .ForMember(entity => entity.SaltUser, member => member.Ignore())
            .ForMember(entity => entity.Teams, prop => prop.Ignore())
            .ForMember(entity => entity.Messages, prop => prop.Ignore());
    }
}