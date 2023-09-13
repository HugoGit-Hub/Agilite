using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobObjectiveCommands.GetAllJobObjectives;

public class GetAllJobObjectivesCommandHandler : IRequestHandler<GetAllJobObjectivesCommand, IEnumerable<JobObjectiveDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllJobObjectivesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IEnumerable<JobObjectiveDto>> Handle(GetAllJobObjectivesCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<JobObjective>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<JobObjectiveDto>>(getAll));
    }
}
