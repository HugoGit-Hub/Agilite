using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using AutoMapper;

namespace Agilite.UI.Mapper.Profiles;

public class TeamProfile : Profile
{
    public TeamProfile()
    {
        CreateMap<TeamDto, TeamModel>();
        CreateMap<TeamModel, TeamDto>()
            .ForMember(dto => dto.IdUser, prop => prop.Ignore());
    }
}