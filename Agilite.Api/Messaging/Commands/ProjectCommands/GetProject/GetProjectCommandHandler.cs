using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.ProjectCommands.GetProject;

public class GetProjectCommandHandler : IRequestHandler<GetProjectCommand, ProjectDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<ProjectDto> Handle(GetProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project
        {
            IdProject = request.id
        };

        var get = _unitOfWork.GetRepositoryEntityById<Project, int>().Get(project.IdProject);
        return Task.FromResult(_mapper.Map<ProjectDto>(get));
    }
}