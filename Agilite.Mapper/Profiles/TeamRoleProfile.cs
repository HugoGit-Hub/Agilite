using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class TeamRoleProfile : Profile
{
    public TeamRoleProfile()
    {
        CreateMap<TeamRole, TeamRoleDto>();
        CreateMap<TeamRoleDto, TeamRole>()
            .ForMember(entity => entity.UserTeamTeamRoles, member => member.Ignore());
    }
}