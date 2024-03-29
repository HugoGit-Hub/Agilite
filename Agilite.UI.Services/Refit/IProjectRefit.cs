﻿using Agilite.DataTransferObject;
using Refit;

namespace Agilite.UI.Services.Refit;

public interface IProjectRefit : IBaseRefitClient
{
    [Post(EndPointConstantes.CreateProject)]
    public Task<ProjectDto> Create(ProjectDto projectDto);

    [Put(EndPointConstantes.UpdateProject)]
    public Task<ProjectDto> Update(ProjectDto entity);

    [Get(EndPointConstantes.AllProjects)]
    public Task<IEnumerable<ProjectDto>> GetAll();

    [Get(EndPointConstantes.AllProjectsOfOneTeam)]
    public Task<IEnumerable<ProjectDto>> GetAllProjectsOfOneTeam(int idTeam);

    [Get(EndPointConstantes.Project)]
    public Task<ProjectDto> Get(int id);

    [Delete(EndPointConstantes.DeleteProject)]
    public Task<ProjectDto> Delete(ProjectDto entity);
}