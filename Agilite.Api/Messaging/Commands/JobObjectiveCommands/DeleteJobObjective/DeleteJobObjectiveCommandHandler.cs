using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobObjectiveCommands.DeleteJobObjective;

public class DeleteJobObjectiveCommandHandler : IRequestHandler<DeleteJobObjectiveCommand, JobObjectiveDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteJobObjectiveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<JobObjectiveDto> Handle(DeleteJobObjectiveCommand request, CancellationToken cancellationToken)
    {
        var jobObjective = new JobObjective
        {
            IdJob = request.JobObjective.IdJob,
            IdObjective = request.JobObjective.IdObjective
        };

        var deleted = _unitOfWork.GetRepository<JobObjective>().Delete(jobObjective);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<JobObjectiveDto>(deleted));
    }
}