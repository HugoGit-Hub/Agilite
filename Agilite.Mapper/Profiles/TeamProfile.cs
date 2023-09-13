using Agilite.DataTransferObject;
using Agilite.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class TeamProfile : Profile
{
    public TeamProfile()
    {
        CreateMap<Team, TeamDto>();
        CreateMap<TeamDto, Team>()
            .ForMember(entity => entity.Users, prop => prop.Ignore())
            .ForMember(entity => entity.Projects, prop => prop.Ignore());
    }
}