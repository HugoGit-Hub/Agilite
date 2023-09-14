using Agilite.DataTransferObject.DTOs;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobCommands.GetJob;

public class GetJobCommandHandler : IRequestHandler<GetJobCommand, JobDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetJobCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<JobDto> Handle(GetJobCommand request, CancellationToken cancellationToken)
    {
        var job = new Job
        {
            IdJob = request.Id
        };

        var get = _unitOfWork.GetRepositoryEntityById<Job, int>().Get(job.IdJob);
        return Task.FromResult(_mapper.Map<JobDto>(get));
    }
}