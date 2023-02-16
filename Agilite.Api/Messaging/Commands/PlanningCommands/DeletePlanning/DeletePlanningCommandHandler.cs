using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.PlanningCommands.DeletePlanning;

public class DeletePlanningCommandHandler : IRequestHandler<DeletePlanningCommand, PlanningDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeletePlanningCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<PlanningDto> Handle(DeletePlanningCommand request, CancellationToken cancellationToken)
    {
        var planning = new Planning
        {
            IdPlanning = request.Planning.IdPlanning,
            UserIdUser = request.Planning.UserIdUser,
            StartDatePlanning = request.Planning.StartDatePlanning,
            EndDatePlanning = request.Planning.EndDatePlanning
        };

        var deleted = _unitOfWork.GetRepository<Planning>().Delete(planning);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<PlanningDto>(deleted));
    }
}