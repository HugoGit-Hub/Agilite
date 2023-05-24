using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobObjectiveCommands.UpdateJobObjective;

public class UpdateJobObjectiveCommandHandler : IRequestHandler<UpdateJobObjectiveCommand, JobObjectiveDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateJobObjectiveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<JobObjectiveDto> Handle(UpdateJobObjectiveCommand request, CancellationToken cancellationToken)
    {
        var jobObjective = new JobObjective
        {
            IdJob = request.JobObjective.IdJob,
            IdObjective = request.JobObjective.IdObjective
        };

        var updated = _unitOfWork.GetRepository<JobObjective>().Update(jobObjective);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<JobObjectiveDto>(updated));
    }
}
