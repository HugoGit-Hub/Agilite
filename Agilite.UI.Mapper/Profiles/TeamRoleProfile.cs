using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using AutoMapper;

namespace Agilite.UI.Mapper.Profiles;

public class TeamRoleProfile : Profile
{
    public TeamRoleProfile()
    {
        CreateMap<TeamRoleDto, TeamRoleModel>();
        CreateMap<TeamRoleModel, TeamRoleDto>();
    }
}