using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class TeamProfile : Profile
{
    public TeamProfile()
    {
        CreateMap<Team, TeamDto>();
        CreateMap<TeamDto, Team>()
            .ForMember(entity => entity.Projects, member => member.Ignore())
            .ForMember(entity => entity.UserTeams, member => member.Ignore());
    }
}