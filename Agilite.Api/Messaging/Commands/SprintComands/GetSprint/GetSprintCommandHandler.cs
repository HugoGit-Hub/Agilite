using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.SprintComands.GetSprint;

public class GetSprintCommandHandler : IRequestHandler<GetSprintCommand, SprintDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSprintCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<SprintDto> Handle(GetSprintCommand request, CancellationToken cancellationToken)
    {
        var sprint = new Sprint
        {
            IdSprint = request.id
        };

        var get = _unitOfWork.GetRepositoryEntityById<Sprint, int>().Get(sprint.IdSprint);
        return Task.FromResult(_mapper.Map<SprintDto>(get));
    }
}