using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserTeamCommands.GetUserTeam;

public class GetUserTeamCommandHandler : IRequestHandler<GetUserTeamCommand, UserTeamDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserTeamCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<UserTeamDto> Handle(GetUserTeamCommand request, CancellationToken cancellationToken)
    {
        var userTeam = new UserTeam
        {
            IdTeam = request.Id
        };

        var get = _unitOfWork.GetRepositoryEntityById<UserTeam, int>().Get(userTeam.IdTeam);
        return Task.FromResult(_mapper.Map<UserTeamDto>(get));
    }
}