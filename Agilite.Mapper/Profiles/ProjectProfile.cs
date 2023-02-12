﻿using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectDto>();
        CreateMap<ProjectDto, Project>()
            .ForMember(entity => entity.Sprints, member => member.Ignore())
            .ForMember(entity => entity.TeamIdTeamNavigation, member => member.Ignore());
    }
}