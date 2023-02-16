using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.TeamRoleCommands.GetTeamRole;

public class GetTeamRoleCommandHandler : IRequestHandler<GetTeamRoleCommand, TeamRoleDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTeamRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<TeamRoleDto> Handle(GetTeamRoleCommand request, CancellationToken cancellationToken)
    {
        var teamRole = new TeamRole
        {
            IdTeamRole = request.id
        };

        var get = _unitOfWork.GetRepositoryEntityById<TeamRole, int>().Get(teamRole.IdTeamRole);
        return Task.FromResult(_mapper.Map<TeamRoleDto>(get));
    }
}
