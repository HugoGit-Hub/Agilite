using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintObjectiveCommands.UpdateSprintObjective;

public class UpdateSprintObjectiveCommandHandler : IRequestHandler<UpdateSprintObjectiveCommand, SprintObjectiveDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateSprintObjectiveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<SprintObjectiveDto> Handle(UpdateSprintObjectiveCommand request, CancellationToken cancellationToken)
    {
        var sprintObjective = new SprintObjective
        {
            IdObjective = request.SprintObjective.IdObjective,
            IdSprint = request.SprintObjective.IdSprint
        };

        var updated = _unitOfWork.GetRepository<SprintObjective>().Update(sprintObjective);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<SprintObjectiveDto>(updated));
    }
}