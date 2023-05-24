using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobStateCommands.GetJobState;

public class GetJobStateCommandHandler : IRequestHandler<GetJobStateCommand, JobStateDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetJobStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<JobStateDto> Handle(GetJobStateCommand request, CancellationToken cancellationToken)
    {
        var jobState = new JobState
        {
            IdJobState = request.Id
        };

        var get = _unitOfWork.GetRepositoryEntityById<JobState, int>().Get(jobState.IdJobState);
        return Task.FromResult(_mapper.Map<JobStateDto>(get));
    }
}