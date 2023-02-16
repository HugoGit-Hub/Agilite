using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.UserTeamTeamRoleCommands.GetAllUserTeamTeamRoles;

public class GetAllUserTeamTeamRolesCommandHandler : IRequestHandler<GetAllUserTeamTeamRolesCommand, IEnumerable<UserTeamTeamRoleDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllUserTeamTeamRolesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IEnumerable<UserTeamTeamRoleDto>> Handle(GetAllUserTeamTeamRolesCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<UserTeamTeamRole>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<UserTeamTeamRoleDto>>(getAll));
    }
}
