using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintObjectiveCommands.GetSprintObjective;

public class GetSprintObjectiveCommandHandler : IRequestHandler<GetSprintObjectiveCommand, SprintObjectiveDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSprintObjectiveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<SprintObjectiveDto> Handle(GetSprintObjectiveCommand request, CancellationToken cancellationToken)
    {
        var sprintObjective = new SprintObjective
        {
            IdObjective = request.Id
        };

        var get = _unitOfWork.GetRepositoryEntityById<SprintObjective, int>().Get(sprintObjective.IdObjective);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<SprintObjectiveDto>(get));
    }
}