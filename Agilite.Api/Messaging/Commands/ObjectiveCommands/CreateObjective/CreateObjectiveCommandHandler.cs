using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveCommands.CreateObjective;

public class CreateObjectiveCommandHandler : IRequestHandler<CreateObjectiveCommand, ObjectiveDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateObjectiveCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Task<ObjectiveDto> Handle(CreateObjectiveCommand request, CancellationToken cancellationToken)
    {
        var objective = new Objective
        {
            IdObjective = request.Objective.IdObjective,
            NameObjective = request.Objective.NameObjective,
            NumberObjective = request.Objective.NumberObjective,
            TextObjective = request.Objective.TextObjective
        };

        var updated = _unitOfWork.GetRepository<Objective>().Create(objective);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<ObjectiveDto>(updated));
    }
}