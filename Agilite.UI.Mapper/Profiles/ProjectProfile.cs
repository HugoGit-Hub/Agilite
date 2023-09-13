using Agilite.DataTransferObject;
using Agilite.UI.Models.Models;
using AutoMapper;

namespace Agilite.UI.Mapper.Profiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<ProjectDto, ProjectModel>();
        CreateMap<ProjectModel, ProjectDto>();
    }
}