using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.Services;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.SprintComands.CreateSprint;

public class CreateSprintCommandHandler : IRequestHandler<CreateSprintCommand, SprintDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ISprintService _service;

    public CreateSprintCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ISprintService service)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _service = service;
    }

    public async Task<SprintDto> Handle(CreateSprintCommand request, CancellationToken cancellationToken)
    {
        var sprint = _mapper.Map<Sprint>(request.Sprint);
        sprint.IdProjectNavigation = _unitOfWork.GetRepositoryEntityById<Project, int>().Get(sprint.FkProject);

        var created = await _service.Create(sprint, cancellationToken);
        
        return _mapper.Map<SprintDto>(created);
    }
}