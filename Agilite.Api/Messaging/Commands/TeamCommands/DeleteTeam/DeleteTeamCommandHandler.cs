using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.TeamCommands.DeleteTeam;

public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, TeamDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteTeamCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<TeamDto> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
        var team = new Team
        {
            IdTeam = request.Team.IdTeam,
            NameTeam = request.Team.NameTeam,
            NumberMembersTeam = request.Team.NumberMembersTeam
        };

        var deleted = _unitOfWork.GetRepository<Team>().Delete(team);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<TeamDto>(deleted));
    }
}