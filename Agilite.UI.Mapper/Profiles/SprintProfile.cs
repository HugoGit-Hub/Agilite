using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using AutoMapper;

namespace Agilite.UI.Mapper.Profiles;

public class SprintProfile : Profile
{
    public SprintProfile()
    {
        CreateMap<SprintDto, SprintModel>();
        CreateMap<SprintModel, SprintDto>();
    }
}