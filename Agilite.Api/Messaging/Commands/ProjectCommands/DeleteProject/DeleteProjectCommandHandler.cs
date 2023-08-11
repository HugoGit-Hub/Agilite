using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

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
            NameProject = request.Project.NameProject,
            FkTeam = request.Project.FkTeam,
            DateCreationProject = request.Project.DateCreationProject,
            DateEndedProject = request.Project.DateEndedProject
        };

        var deleted = _unitOfWork.GetRepository<Project>().Delete(project);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<ProjectDto>(deleted));
    }
}
