using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.TeamCommands.UpdateTeam;

public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, TeamDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateTeamCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<TeamDto> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
    {
        var team = new Team
        {
            IdTeam = request.Team.IdTeam,
            NameTeam = request.Team.NameTeam,
            NumberOfMembersTeam = request.Team.NumberMembersTeam
        };

        var created = _unitOfWork.GetRepository<Team>().Update(team);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<TeamDto>(created));
    }
}
