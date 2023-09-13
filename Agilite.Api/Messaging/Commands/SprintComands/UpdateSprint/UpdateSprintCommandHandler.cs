using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintComands.UpdateSprint;

public class UpdateSprintCommandHandler : IRequestHandler<UpdateSprintCommand, SprintDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateSprintCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<SprintDto> Handle(UpdateSprintCommand request, CancellationToken cancellationToken)
    {
        var sprint = new Sprint
        {
            IdSprint = request.Sprint.IdSprint,
            NumberSprint = request.Sprint.NumberSprint,
            StartDateSprint = request.Sprint.StartDateSprint,
            EndDateSprint = request.Sprint.EndDateSprint
        };

        var created = _unitOfWork.GetRepository<Sprint>().Update(sprint);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<SprintDto>(created));
    }
}
