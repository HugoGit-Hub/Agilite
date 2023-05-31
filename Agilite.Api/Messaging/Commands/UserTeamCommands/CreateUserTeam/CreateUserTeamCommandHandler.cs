using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserTeamCommands.CreateUserTeam;

public class CreateUserTeamCommandHandler : IRequestHandler<CreateUserTeamCommand, UserTeamDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserTeamCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<UserTeamDto> Handle(CreateUserTeamCommand request, CancellationToken cancellationToken)
    {
        var userTeam = new UserTeam
        {
            IdTeam = request.UserTeam.IdTeam,
            IdUser = request.UserTeam.IdUser
        };

        var created = _unitOfWork.GetRepository<UserTeam>().Create(userTeam);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<UserTeamDto>(created));
    }
}