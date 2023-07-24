using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserCommands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            IdUser = request.User.IdUser,
            FirstNameUser = request.User.FirstNameUser,
            LastNameUser = request.User.LastNameUser,
            EmailUser = request.User.EmailUser,
            PasswordUser = request.User.PasswordUser,
            DateCreationUser = request.User.DateCreationUser,
            AgeUser = request.User.AgeUser,
        };

        var result = _unitOfWork.GetRepository<User>().Update(user);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<UserDto>(result));
    }
}