using Agilite.DataTransferObject;
using Agilite.Services;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveCommands.GetAllObjectivesOfOneSprint;

public class GetAllObjectivesOfOneSprintHandler : IRequestHandler<GetAllObjectivesOfOneSprintCommand, IEnumerable<ObjectiveDto>>
{
    private readonly IMapper _mapper;
    private readonly IObjectiveService _service;

    public GetAllObjectivesOfOneSprintHandler(IMapper mapper, IObjectiveService service)
    {
        _mapper = mapper;
        _service = service;
    }

    public async Task<IEnumerable<ObjectiveDto>> Handle(GetAllObjectivesOfOneSprintCommand request, CancellationToken cancellationToken)
    {
        var result = await _service.GetAllObjectivesOfOneSprint(request.IdSprint);
        return _mapper.Map<IEnumerable<ObjectiveDto>>(result);
    }
}