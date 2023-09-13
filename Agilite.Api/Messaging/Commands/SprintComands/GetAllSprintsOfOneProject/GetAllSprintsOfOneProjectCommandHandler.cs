using Agilite.DataTransferObject;
using Agilite.Services;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintComands.GetAllSprintsOfOneProject;

public class GetAllSprintsOfOneProjectCommandHandler : IRequestHandler<GetAllSprintsOfOneProjectCommand, IEnumerable<SprintDto>>
{
    private readonly IMapper _mapper;
    private readonly ISprintService _service;

    public GetAllSprintsOfOneProjectCommandHandler(IMapper mapper, ISprintService service)
    {
        _mapper = mapper;
        _service = service;
    }

    public async Task<IEnumerable<SprintDto>> Handle(GetAllSprintsOfOneProjectCommand request, CancellationToken cancellationToken)
    {
        var result = await _service.GetAllSprintsOfOneProject(request.IdProject, cancellationToken);
        return _mapper.Map<IEnumerable<SprintDto>>(result);
    }
}