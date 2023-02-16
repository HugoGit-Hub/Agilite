using Agilite.DataTransferObject.DTOs;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.TaskCommands.GetAllTasks;

public class GetAllTasksCommandHandler : IRequestHandler<GetAllTasksCommand, IEnumerable<TaskDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllTasksCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<TaskDto>> Handle(GetAllTasksCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<Entities.Entities.Task>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<TaskDto>>(getAll));
    }
}
