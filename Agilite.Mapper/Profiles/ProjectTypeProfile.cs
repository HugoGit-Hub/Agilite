using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class ProjectTypeProfile : Profile
{
    public ProjectTypeProfile()
    {
        CreateMap<ProjectType, ProjectTypeDto>();
        CreateMap<ProjectTypeDto, ProjectType>()
            .ForMember(entity => entity.Projects, member => member.Ignore());
    }
}