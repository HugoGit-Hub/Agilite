using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintComands.CreateSprint;

public class CreateSprintCommandHandler : IRequestHandler<CreateSprintCommand, SprintDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateSprintCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<SprintDto> Handle(CreateSprintCommand request, CancellationToken cancellationToken)
    {
        var sprint = new Sprint
        {
            IdSprint = request.Sprint.IdSprint,
            NumberSprint = request.Sprint.NumberSprint,
            StartDateSprint = request.Sprint.StartDateSprint,
            EndDateSprint = request.Sprint.EndDateSprint
        };

        var created = _unitOfWork.GetRepository<Sprint>().Create(sprint);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<SprintDto>(created));
    }
}