using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class TeamUserProfile : Profile
{
    public TeamUserProfile()
    {
        CreateMap<TeamUser, TeamUserDto>();
        CreateMap<TeamUserDto, TeamUser>();
    }
}