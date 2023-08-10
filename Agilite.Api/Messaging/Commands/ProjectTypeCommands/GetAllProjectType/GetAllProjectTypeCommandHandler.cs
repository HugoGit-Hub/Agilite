using Agilite.DataTransferObject.DTOs;
using Agilite.Services;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ProjectTypeCommands.GetAllProjectType;

public class GetAllProjectTypeCommandHandler : IRequestHandler<GetAllProjectTypeCommand, IEnumerable<ProjectTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly IProjectTypeService _service;

    public GetAllProjectTypeCommandHandler(IMapper mapper, IProjectTypeService service)
    {
        _mapper = mapper;
        _service = service;
    }

    public async Task<IEnumerable<ProjectTypeDto>> Handle(GetAllProjectTypeCommand request, CancellationToken cancellationToken)
    {
        var result = await _service.GetAllProjectType(cancellationToken);
        return _mapper.Map<IEnumerable<ProjectTypeDto>>(result);
    }
}