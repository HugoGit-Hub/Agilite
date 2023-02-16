using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.UserTeamTeamRoleCommands.DeleteUserTeamTeamRole;

public class DeleteUserTeamTeamRoleCommandHandler : IRequestHandler<DeleteUserTeamTeamRoleCommand, UserTeamTeamRoleDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteUserTeamTeamRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<UserTeamTeamRoleDto> Handle(DeleteUserTeamTeamRoleCommand request, CancellationToken cancellationToken)
    {
        var userTeamTeamRole = new UserTeamTeamRole
        {
            UserIdUser = request.UserTeamTeamRole.UserIdUser,
            TeamIdTeam = request.UserTeamTeamRole.TeamIdTeam,
            TeamRoleIdTeamRole = request.UserTeamTeamRole.TeamRoleIdTeamRole,
            DateTimeUserTeamTeamRole = request.UserTeamTeamRole.DateTimeUserTeamTeamRole
        };

        var deleted = _unitOfWork.GetRepository<UserTeamTeamRole>().Update(userTeamTeamRole);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<UserTeamTeamRoleDto>(deleted));
    }
}