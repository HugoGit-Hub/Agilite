using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.ProjectCommands.DeleteProject;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, ProjectDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<ProjectDto> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project
        {
            IdProject = request.Project.IdProject,
            TeamIdTeam = request.Project.TeamIdTeam,
            NameProject = request.Project.NameProject,
            DateCreationProject = request.Project.DateCreationProject,
            DateEnded = request.Project.DateEnded
        };

        var deleted = _unitOfWork.GetRepository<Project>().Delete(project);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<ProjectDto>(deleted));
    }
}
