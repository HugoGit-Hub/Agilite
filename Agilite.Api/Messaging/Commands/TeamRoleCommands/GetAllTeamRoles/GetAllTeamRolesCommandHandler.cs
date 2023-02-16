using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.TeamRoleCommands.GetAllTeamRoles;

public class GetAllTeamRolesCommandHandler : IRequestHandler<GetAllTeamRolesCommand, IEnumerable<TeamRoleDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllTeamRolesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IEnumerable<TeamRoleDto>> Handle(GetAllTeamRolesCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<TeamRole>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<TeamRoleDto>>(getAll));
    }
}