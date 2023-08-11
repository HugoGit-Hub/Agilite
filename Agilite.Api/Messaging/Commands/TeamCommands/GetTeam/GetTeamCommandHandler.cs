using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamCommands.GetTeam;

public class GetTeamCommandHandler : IRequestHandler<GetTeamCommand, TeamDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTeamCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<TeamDto> Handle(GetTeamCommand request, CancellationToken cancellationToken)
    {
        var team = new Team
        {
            IdTeam = request.id
        };

        var get = _unitOfWork.GetRepositoryEntityById<Team, int>().Get(team.IdTeam);
        return Task.FromResult(_mapper.Map<TeamDto>(get));
    }
}
