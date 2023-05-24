using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserContactCommands.DeleteUserContact;

public class DeleteUserContactCommandHandler : IRequestHandler<DeleteUserContactCommand, UserContactDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteUserContactCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<UserContactDto> Handle(DeleteUserContactCommand request, CancellationToken cancellationToken)
    {
        var userContact = new UserContact
        {
            IdContact = request.UserContact.IdContact,
            IdUser = request.UserContact.IdUser
        };

        var deleted = _unitOfWork.GetRepository<UserContact>().Delete(userContact);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<UserContactDto>(deleted));
    }
}