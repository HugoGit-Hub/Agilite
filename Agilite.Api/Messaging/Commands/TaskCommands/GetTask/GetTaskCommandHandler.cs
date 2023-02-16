using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.TaskCommands.GetTask;

public class GetTaskCommandHandler : IRequestHandler<GetTaskCommand, TaskDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<TaskDto> Handle(GetTaskCommand request, CancellationToken cancellationToken)
    {
        var sprint = new Sprint
        {
            IdSprint = request.id
        };

        var get = _unitOfWork.GetRepositoryEntityById<Entities.Entities.Task, int>().Get(sprint.IdSprint);
        return Task.FromResult(_mapper.Map<TaskDto>(get));
    }
}