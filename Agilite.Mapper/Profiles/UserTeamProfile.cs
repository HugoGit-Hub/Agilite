using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class UserTeamProfile : Profile
{
    public UserTeamProfile()
    {
        CreateMap<UserTeam, UserTeamDto>();
        CreateMap<UserTeamDto, UserTeam>()
            .ForMember(entity => entity.IdTeamNavigation, member => member.Ignore())
            .ForMember(entity => entity.IdUserNavigation, member => member.Ignore());
    }
}