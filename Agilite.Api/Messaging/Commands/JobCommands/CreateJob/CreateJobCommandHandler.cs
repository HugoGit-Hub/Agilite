using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobCommands.CreateJob;

public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, JobDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateJobCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<JobDto> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
            var job = new Job
        {
            IdJob = request.Job.IdJob,
            NameJob = request.Job.NameJob,
            NumberJob = request.Job.NumberJob,
            TextJob = request.Job.TextJob,
            StartLogTimeJob = request.Job.StartLogTimeJob,
            EndLogTimeJob = request.Job.EndLogTimeJob
        };

        var created = _unitOfWork.GetRepository<Job>().Create(job);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<JobDto>(created));
    }
}
