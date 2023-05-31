using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobCommands.UpdateJob;

public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, JobDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateJobCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<JobDto> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
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

        var created = _unitOfWork.GetRepository<Job>().Update(job);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<JobDto>(created));
    }
}