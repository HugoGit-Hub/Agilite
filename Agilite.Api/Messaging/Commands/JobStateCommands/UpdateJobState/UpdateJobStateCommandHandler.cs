using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobStateCommands.UpdateJobState;

public class UpdateJobStateCommandHandler : IRequestHandler<UpdateJobStateCommand, JobStateDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateJobStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<JobStateDto> Handle(UpdateJobStateCommand request, CancellationToken cancellationToken)
    {
        var jobState = new JobState
        {
            IdJobState = request.JobState.IdJobState,
            NameJobState = request.JobState.NameJobState
        };

        var updated = _unitOfWork.GetRepository<JobState>().Update(jobState);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<JobStateDto>(updated));
    }
}