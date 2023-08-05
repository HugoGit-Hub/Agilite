using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

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
        var user = _unitOfWork.GetRepositoryEntityById<User, int>().Get(request.Team.IdUser);

        var team = new Team
        {
            IdTeam = request.Team.IdTeam,
            NameTeam = request.Team.NameTeam,
            NumberOfMembersTeam = request.Team.NumberMembersTeam,
            Users = new[] { user }!
        };

        var created = _unitOfWork.GetRepository<Team>().Create(team);
        _unitOfWork.Save();

        return Task.FromResult(_mapper.Map<TeamDto>(created));
    }
}