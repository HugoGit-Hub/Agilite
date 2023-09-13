using Agilite.DataTransferObject;
using Agilite.Entities;
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
        var project = _mapper.Map<Project>(request.Dto);
        var team = _unitOfWork.GetRepositoryEntityById<Team, int>().Get(request.Dto.FkTeam) ?? throw new ArgumentNullException();
        project.FkTeam = request.Dto.FkTeam;
        project.NameProject = request.Dto.NameProject;
        project.DateCreationProject = DateTime.Now;
        project.DateEndedProject = DateTime.Now;
        project.IdTeamNavigation = team;

        var created = _unitOfWork.GetRepository<Project>().Create(project);
        _unitOfWork.Save();

        return Task.FromResult(_mapper.Map<ProjectDto>(created));
    }
}
