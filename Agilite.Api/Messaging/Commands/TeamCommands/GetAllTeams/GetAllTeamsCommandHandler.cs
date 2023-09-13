using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.TeamCommands.GetAllTeams;

public class GetAllTeamsCommandHandler : IRequestHandler<GetAllTeamsCommand, IEnumerable<TeamDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllTeamsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<TeamDto>> Handle(GetAllTeamsCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<Team>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<TeamDto>>(getAll));
    }
}
