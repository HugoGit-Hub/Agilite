using Agilite.DataTransferObject.DTOs;
using Agilite.Services;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.JobCommands.GetAllJobsOfOneObjective;

public class GetAllJobsOfOneObjectiveCommandHandler : IRequestHandler<GetAllJobsOfOneObjectiveCommand, IEnumerable<JobDto>>
{
    private readonly IMapper _mapper;
    private readonly IJobService _service;

    public GetAllJobsOfOneObjectiveCommandHandler(IMapper mapper, IJobService service)
    {
        _mapper = mapper;
        _service = service;
    }

    public async Task<IEnumerable<JobDto>> Handle(GetAllJobsOfOneObjectiveCommand request, CancellationToken cancellationToken)
    {
        var result = await _service.GetAllJobsOfOneObjective(request.Id, cancellationToken);
        return _mapper.Map<IEnumerable<JobDto>>(result);
    }
}