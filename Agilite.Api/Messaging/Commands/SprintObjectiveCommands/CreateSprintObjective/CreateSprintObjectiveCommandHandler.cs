using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintObjectiveCommands.CreateSprintObjective;

public class CreateSprintObjectiveCommandHandler : IRequestHandler<CreateSprintObjectiveCommand, SprintObjectiveDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateSprintObjectiveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<SprintObjectiveDto> Handle(CreateSprintObjectiveCommand request, CancellationToken cancellationToken)
    {
        var sprintObjective = new SprintObjective
        {
            IdObjective = request.SprintObjective.IdObjective,
            IdSprint = request.SprintObjective.IdSprint
        };

        var created = _unitOfWork.GetRepository<SprintObjective>().Create(sprintObjective);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<SprintObjectiveDto>(created));
    }
}