using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobObjectiveCommands.GetJobObjective;

public class GetJobObjectiveCommandHandler : IRequestHandler<GetJobObjectiveCommand, JobObjectiveDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetJobObjectiveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<JobObjectiveDto> Handle(GetJobObjectiveCommand request, CancellationToken cancellationToken)
    {
        var jobObjective = new JobObjective
        {
            IdJob = request.Id
        };

        var get = _unitOfWork.GetRepositoryEntityById<JobObjective, int>().Get(jobObjective.IdJob);
        return Task.FromResult(_mapper.Map<JobObjectiveDto>(get));
    }
}
