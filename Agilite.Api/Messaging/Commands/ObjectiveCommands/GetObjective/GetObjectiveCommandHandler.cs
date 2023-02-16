using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.ObjectiveCommands.GetObjective;

public class GetObjectiveCommandHandler : IRequestHandler<GetObjectiveCommand, ObjectiveDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetObjectiveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<ObjectiveDto> Handle(GetObjectiveCommand request, CancellationToken cancellationToken)
    {
        var objective = new Objective
        {
            IdObjective = request.id
        };

        var get = _unitOfWork.GetRepositoryEntityById<Objective, int>().Get(objective.IdObjective);
        return Task.FromResult(_mapper.Map<ObjectiveDto>(get));
    }
}