using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ProjectCommands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ProjectDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<ProjectDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project
        {
            IdProject = request.Project.IdProject,
            NameProject = request.Project.NameProject,
            DateCreationProject = request.Project.DateCreationProject,
            DateEndedProject = request.Project.DateEndedProject
        };

        var created = _unitOfWork.GetRepository<Project>().Create(project);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<ProjectDto>(created));
    }
}
