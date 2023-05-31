using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobCommands.GetAllJobs;

public class GetAllJobsCommandHandler : IRequestHandler<GetAllJobsCommand, IEnumerable<JobDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllJobsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<JobDto>> Handle(GetAllJobsCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<Job>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<JobDto>>(getAll));
    }
}
