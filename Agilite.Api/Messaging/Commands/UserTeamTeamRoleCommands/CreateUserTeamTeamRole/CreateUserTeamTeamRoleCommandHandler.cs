using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.UserTeamTeamRoleCommands.CreateUserTeamTeamRole;

public class CreateUserTeamTeamRoleCommandHandler : IRequestHandler<CreateUserTeamTeamRoleCommand, UserTeamTeamRoleDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserTeamTeamRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<UserTeamTeamRoleDto> Handle(CreateUserTeamTeamRoleCommand request, CancellationToken cancellationToken)
    {
        var userTeamTeamRole = new UserTeamTeamRole
        {
            UserIdUser = request.UserTeamTeamRole.UserIdUser,
            TeamIdTeam = request.UserTeamTeamRole.TeamIdTeam,
            TeamRoleIdTeamRole = request.UserTeamTeamRole.TeamRoleIdTeamRole,
            DateTimeUserTeamTeamRole = request.UserTeamTeamRole.DateTimeUserTeamTeamRole
        };

        var created = _unitOfWork.GetRepository<UserTeamTeamRole>().Create(userTeamTeamRole);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<UserTeamTeamRoleDto>(created));
    }
}