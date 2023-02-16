using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.PlanningCommands.GetPlanning;

public class GetPlanningCommandHandler : IRequestHandler<GetPlanningCommand, PlanningDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPlanningCommandHandler(IUnitOfWork nunitOfWork, IMapper mapper)
    {
        _unitOfWork = nunitOfWork;
        _mapper = mapper;
    }

    public Task<PlanningDto> Handle(GetPlanningCommand request, CancellationToken cancellationToken)
    {
        var contact = new Planning
        {
            IdPlanning = request.id
        };

        var get = _unitOfWork.GetRepositoryEntityById<Planning, int>().Get(contact.IdPlanning);
        return Task.FromResult(_mapper.Map<PlanningDto>(get));
    }
}
