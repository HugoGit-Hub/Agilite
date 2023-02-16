﻿using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.TeamRoleCommands.UpdateTeamRole;

public class UpdateTeamRoleCommandHandler : IRequestHandler<UpdateTeamRoleCommand, TeamRoleDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateTeamRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<TeamRoleDto> Handle(UpdateTeamRoleCommand request, CancellationToken cancellationToken)
    {
        var teamRole = new TeamRole
        {
            IdTeamRole = request.TeamRole.IdTeamRole,
            TitleTeamRole = request.TeamRole.TitleTeamRole,
            AccessTeamRole = request.TeamRole.AccessTeamRole
        };

        var created = _unitOfWork.GetRepository<TeamRole>().Update(teamRole);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<TeamRoleDto>(created));
    }
}
