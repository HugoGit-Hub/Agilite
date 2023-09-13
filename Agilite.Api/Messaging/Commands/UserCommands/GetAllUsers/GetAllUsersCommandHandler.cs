using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserCommands.GetAllUsers;

public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersCommand, IEnumerable<UserDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllUsersCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IEnumerable<UserDto>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
    {
        var result = _unitOfWork.GetRepository<User>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<UserDto>>(result));
    }
}