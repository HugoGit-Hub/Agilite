using Agilite.DataTransferObject.DTOs;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.TaskCommands.UpdateTask;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<TaskDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new Entities.Entities.Task
        {
            IdTask = request.Task.IdTask,
            ObjectiveIdObjective = request.Task.ObjectiveIdObjective,
            NameTask = request.Task.NameTask,
            NumberTask = request.Task.NumberTask,
            EnumTypeTask = request.Task.EnumTypeTask,
            EnumStateTask = request.Task.EnumStateTask,
            TextTask = request.Task.TextTask,
            StartLogTimeTask = request.Task.StartLogTimeTask,
            EndLogTimeTask = request.Task.EndLogTimeTask
        };

        var created = _unitOfWork.GetRepository<Entities.Entities.Task>().Update(task);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<TaskDto>(created));
    }
}