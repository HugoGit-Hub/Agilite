using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.SprintComands.DeleteSprint;

public class DeleteSprintCommandHandler : IRequestHandler<DeleteSprintCommand, SprintDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteSprintCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<SprintDto> Handle(DeleteSprintCommand request, CancellationToken cancellationToken)
    {
        var sprint = new Sprint
        {
            IdSprint = request.Sprint.IdSprint,
            ProjectIdProject = request.Sprint.ProjectIdProject,
            NumberSprint = request.Sprint.NumberSprint,
            StartDateSprint = request.Sprint.StartDateSprint,
            EndDateSprint = request.Sprint.EndDateSprint
        };

        var deleted = _unitOfWork.GetRepository<Sprint>().Delete(sprint);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<SprintDto>(deleted));
    }
}