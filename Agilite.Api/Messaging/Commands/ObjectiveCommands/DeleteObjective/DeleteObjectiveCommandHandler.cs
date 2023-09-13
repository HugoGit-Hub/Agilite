using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveCommands.DeleteObjective;

public class DeleteObjectiveCommandHandler : IRequestHandler<DeleteObjectiveCommand, ObjectiveDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteObjectiveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<ObjectiveDto> Handle(DeleteObjectiveCommand request, CancellationToken cancellationToken)
    {
        var objective = new Objective
        {
            IdObjective = request.Objective.IdObjective,
            NameObjective = request.Objective.NameObjective,
            NumberObjective = request.Objective.NumberObjective,
            TextObjective = request.Objective.TextObjective
        };

        var deleted = _unitOfWork.GetRepository<Objective>().Delete(objective);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<ObjectiveDto>(deleted));
    }
}