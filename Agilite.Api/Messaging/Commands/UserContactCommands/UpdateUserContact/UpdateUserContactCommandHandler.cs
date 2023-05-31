using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserContactCommands.UpdateUserContact;

public class UpdateUserContactCommandHandler : IRequestHandler<UpdateUserContactCommand, UserContactDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserContactCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<UserContactDto> Handle(UpdateUserContactCommand request, CancellationToken cancellationToken)
    {
        var userContact = new UserContact
        {
            IdContact = request.UserContact.IdContact,
            IdUser = request.UserContact.IdUser
        };

        var updated = _unitOfWork.GetRepository<UserContact>().Update(userContact);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<UserContactDto>(updated));
    }
}