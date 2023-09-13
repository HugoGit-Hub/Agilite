using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.ProjectCommands.GetAllProjects;

public class GetAllProjectsCommandHandler : IRequestHandler<GetAllProjectsCommand, IEnumerable<ProjectDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllProjectsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<ProjectDto>> Handle(GetAllProjectsCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<Project>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<ProjectDto>>(getAll));
    }
}
