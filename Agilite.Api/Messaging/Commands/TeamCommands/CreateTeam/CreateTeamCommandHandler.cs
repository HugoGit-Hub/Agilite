using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.TeamCommands.CreateTeam;

public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, TeamDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateTeamCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<TeamDto> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var team = new Team
        {
            IdTeam = request.Team.IdTeam,
            NameTeam = request.Team.NameTeam,
            NumberMembersTeam = request.Team.NumberMembersTeam
        };

        var created = _unitOfWork.GetRepository<Team>().Create(team);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<TeamDto>(created));
    }
}