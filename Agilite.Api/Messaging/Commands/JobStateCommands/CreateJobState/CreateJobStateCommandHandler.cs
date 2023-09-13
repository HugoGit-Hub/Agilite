using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobStateCommands.CreateJobState;

public class CreateJobStateCommandHandler : IRequestHandler<CreateJobStateCommand, JobStateDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateJobStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<JobStateDto> Handle(CreateJobStateCommand request, CancellationToken cancellationToken)
    {
        var jobState = new JobState
        {
            IdJobState = request.JobState.IdJobState,
            NameJobState = request.JobState.NameJobState
        };

        var created = _unitOfWork.GetRepository<JobState>().Create(jobState);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<JobStateDto>(created));
    }
}