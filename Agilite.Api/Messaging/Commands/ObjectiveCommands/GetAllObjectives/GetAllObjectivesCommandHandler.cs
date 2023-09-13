using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.ObjectiveCommands.GetAllObjectives;

public class GetAllObjectivesCommandHandler : IRequestHandler<GetAllObjectivesCommand, IEnumerable<ObjectiveDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllObjectivesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IEnumerable<ObjectiveDto>> Handle(GetAllObjectivesCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<Objective>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<ObjectiveDto>>(getAll));
    }
}