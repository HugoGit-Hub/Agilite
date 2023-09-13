using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveCommands.UpdateObjective;

public class UpdateObjectiveCommandHandler : IRequestHandler<UpdateObjectiveCommand, ObjectiveDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateObjectiveCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Task<ObjectiveDto> Handle(UpdateObjectiveCommand request, CancellationToken cancellationToken)
    {
        var objective = new Objective
        {
            IdObjective = request.Objective.IdObjective,
            NameObjective = request.Objective.NameObjective,
            NumberObjective = request.Objective.NumberObjective,
            TextObjective = request.Objective.TextObjective,
        };

        var updated = _unitOfWork.GetRepository<Objective>().Update(objective);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<ObjectiveDto>(updated));
    }
}