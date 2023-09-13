using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobStateCommands.GetAllJobStates;

public class GetAllJobStatesCommandHandler : IRequestHandler<GetAllJobStatesCommand, IEnumerable<JobStateDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllJobStatesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IEnumerable<JobStateDto>> Handle(GetAllJobStatesCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<JobState>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<JobStateDto>>(getAll));
    }
}