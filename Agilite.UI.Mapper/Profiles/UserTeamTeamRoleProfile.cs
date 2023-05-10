using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using AutoMapper;

namespace Agilite.UI.Mapper.Profiles;

public class UserTeamTeamRoleProfile : Profile
{
    public UserTeamTeamRoleProfile()
    {
        CreateMap<UserTeamTeamRoleDto, UserTeamTeamRoleModel>();
        CreateMap<UserTeamTeamRoleModel, UserTeamTeamRoleDto>();
    }
}