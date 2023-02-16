using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.ProjectCommands.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, ProjectDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper iMapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = iMapper;
    }

    public Task<ProjectDto> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project
        {
            IdProject = request.Project.IdProject,
            TeamIdTeam = request.Project.TeamIdTeam,
            NameProject = request.Project.NameProject,
            DateCreationProject = request.Project.DateCreationProject,
            DateEnded = request.Project.DateEnded
        };

        var created = _unitOfWork.GetRepository<Project>().Update(project);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<ProjectDto>(created));
    }
}