using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserTeamCommands.DeleteUserTeam;

public class DeleteUserTeamCommandHandler : IRequestHandler<DeleteUserTeamCommand, UserTeamDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteUserTeamCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<UserTeamDto> Handle(DeleteUserTeamCommand request, CancellationToken cancellationToken)
    {
        var userTeam = new UserTeam
        {
            IdTeam = request.UserTeam.IdTeam,
            IdUser = request.UserTeam.IdUser
        };

        var deleted = _unitOfWork.GetRepository<UserTeam>().Delete(userTeam);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<UserTeamDto>(deleted));
    }
}
