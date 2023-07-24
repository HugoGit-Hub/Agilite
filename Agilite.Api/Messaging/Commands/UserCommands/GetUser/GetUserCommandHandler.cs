using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.UserCommands.GetUser;

public class GetUserCommandHandler : IRequestHandler<GetUserCommand, UserDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<UserDto> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            IdUser = request.id
        };

        var result = _unitOfWork.GetRepositoryEntityById<User, int>().Get(user.IdUser);
        return Task.FromResult(_mapper.Map<UserDto>(result)); ;
    }
}
