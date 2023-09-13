using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobStateCommands.DeleteJobState;

public class DeleteJobStateCommandHandler : IRequestHandler<DeleteJobStateCommand, JobStateDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteJobStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<JobStateDto> Handle(DeleteJobStateCommand request, CancellationToken cancellationToken)
    {
        var jobState = new JobState
        {
            IdJobState = request.JobState.IdJobState,
            NameJobState = request.JobState.NameJobState
        };

        var deleted = _unitOfWork.GetRepository<JobState>().Delete(jobState);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<JobStateDto>(deleted));
    }
}