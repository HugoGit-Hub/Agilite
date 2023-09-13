using Agilite.DataTransferObject;
using Agilite.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectDto>();
        CreateMap<ProjectDto, Project>()
            .ForMember(entity => entity.IdTeamNavigation, member => member.Ignore())
            .ForMember(entity => entity.Sprints, member => member.Ignore());
    }
}