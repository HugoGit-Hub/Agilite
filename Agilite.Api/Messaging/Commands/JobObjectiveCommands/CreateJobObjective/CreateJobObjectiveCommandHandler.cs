using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobObjectiveCommands.CreateJobObjective;

public class CreateJobObjectiveCommandHandler : IRequestHandler<CreateJobObjectiveCommand, JobObjectiveDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateJobObjectiveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<JobObjectiveDto> Handle(CreateJobObjectiveCommand request, CancellationToken cancellationToken)
    {
        var jobObjective = new JobObjective()
        {
            IdJob = request.JobObjective.IdJob,
            IdObjective = request.JobObjective.IdObjective
        };

        var created = _unitOfWork.GetRepository<JobObjective>().Create(jobObjective);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<JobObjectiveDto>(created));
    }
}