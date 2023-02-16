using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.SprintComands.GetAllSprints;

public class GetAllSprintsCommandHandler : IRequestHandler<GetAllSprintsCommand, IEnumerable<SprintDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllSprintsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<SprintDto>> Handle(GetAllSprintsCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<Sprint>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<SprintDto>>(getAll));
    }
}
