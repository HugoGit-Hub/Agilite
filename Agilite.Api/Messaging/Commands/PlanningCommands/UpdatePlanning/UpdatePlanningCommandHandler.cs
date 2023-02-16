using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.PlanningCommands.UpdatePlanning;

public class UpdatePlanningCommandHandler : IRequestHandler<UpdatePlanningCommand, PlanningDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdatePlanningCommandHandler(IUnitOfWork unitOfWork, IMapper iMapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = iMapper;
    }

    public Task<PlanningDto> Handle(UpdatePlanningCommand request, CancellationToken cancellationToken)
    {
        var planning = new Planning
        {
            IdPlanning = request.Planning.IdPlanning,
            UserIdUser = request.Planning.UserIdUser,
            StartDatePlanning = request.Planning.StartDatePlanning,
            EndDatePlanning = request.Planning.EndDatePlanning
        };

        var created = _unitOfWork.GetRepository<Planning>().Update(planning);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<PlanningDto>(created));
    }
}