using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using AutoMapper;

namespace Agilite.UI.Mapper.Profiles;

public class PlanningProfile : Profile
{
    public PlanningProfile()
    {
        CreateMap<PlanningDto, PlanningModel>();
        CreateMap<PlanningModel, PlanningDto>();
    }
}