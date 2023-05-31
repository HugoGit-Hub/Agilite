using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintObjectiveCommands.DeleteSprintObjective;

public class DeleteSprintObjectiveCommandHandler : IRequestHandler<DeleteSprintObjectiveCommand, SprintObjectiveDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteSprintObjectiveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<SprintObjectiveDto> Handle(DeleteSprintObjectiveCommand request, CancellationToken cancellationToken)
    {
        var sprintObjective = new SprintObjective
        {
            IdObjective = request.SprintObjective.IdObjective,
            IdSprint = request.SprintObjective.IdSprint
        };

        var deleted = _unitOfWork.GetRepository<SprintObjective>().Delete(sprintObjective);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<SprintObjectiveDto>(deleted));
    }
}