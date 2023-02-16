using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.PlanningCommands.CreatePlanning;

public class CreatePlanningCommandHandler : IRequestHandler<CreatePlanningCommand, PlanningDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePlanningCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<PlanningDto> Handle(CreatePlanningCommand request, CancellationToken cancellationToken)
    {
        var planning = new Planning
        {
            IdPlanning = request.Planning.IdPlanning,
            UserIdUser = request.Planning.UserIdUser,
            StartDatePlanning = request.Planning.StartDatePlanning,
            EndDatePlanning = request.Planning.EndDatePlanning
        };

        var created = _unitOfWork.GetRepository<Planning>().Create(planning);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<PlanningDto>(created));
    }
}