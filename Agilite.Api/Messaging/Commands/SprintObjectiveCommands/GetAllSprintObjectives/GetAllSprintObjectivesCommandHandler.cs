using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintObjectiveCommands.GetAllSprintObjectives;

public class GetAllSprintObjectivesCommandHandler : IRequestHandler<GetAllSprintObjectivesCommand, IEnumerable<SprintObjectiveDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllSprintObjectivesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IEnumerable<SprintObjectiveDto>> Handle(GetAllSprintObjectivesCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<SprintObjective>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<SprintObjectiveDto>>(getAll));
    }
}