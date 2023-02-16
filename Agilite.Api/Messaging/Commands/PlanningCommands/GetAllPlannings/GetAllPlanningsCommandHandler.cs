using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.PlanningCommands.GetAllPlannings;

public class GetAllPlanningsCommandHandler : IRequestHandler<GetAllPlanningsCommand, IEnumerable<PlanningDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllPlanningsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<PlanningDto>> Handle(GetAllPlanningsCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<Planning>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<PlanningDto>>(getAll));
    }
}