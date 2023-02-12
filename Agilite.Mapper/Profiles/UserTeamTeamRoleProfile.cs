using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class UserTeamTeamRoleProfile : Profile
{
    public UserTeamTeamRoleProfile()
    {
        CreateMap<UserTeamTeamRole, UserTeamTeamRoleDto>();
        CreateMap<UserTeamTeamRoleDto, UserTeamTeamRole>()
            .ForMember(entity => entity.TeamIdTeamNavigation, member => member.Ignore())
            .ForMember(entity => entity.TeamRoleIdTeamRoleNavigation, member => member.Ignore())
            .ForMember(entity => entity.UserIdUserNavigation, member => member.Ignore());
    }
}