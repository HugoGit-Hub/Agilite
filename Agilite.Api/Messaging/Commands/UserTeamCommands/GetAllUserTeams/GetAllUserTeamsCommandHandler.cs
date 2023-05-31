using Agilite.DataTransferObject.DTOs;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserTeamCommands.GetAllUserTeams;

public class GetAllUserTeamsCommandHandler : IRequestHandler<GetAllUserTeamsCommand, IEnumerable<UserTeamDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllUserTeamsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IEnumerable<UserTeamDto>> Handle(GetAllUserTeamsCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<IEnumerable<UserTeamDto>>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<UserTeamDto>>(getAll));
    }
}