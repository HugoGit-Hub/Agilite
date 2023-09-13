using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobCommands.DeleteJob;

public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand, JobDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteJobCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public Task<JobDto> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
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

        var created = _unitOfWork.GetRepository<Job>().Delete(job);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<JobDto>(created));
    }
}