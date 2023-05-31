using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserContactCommands.CreateUserContact;

public class CreateUserContactCommandHandler : IRequestHandler<CreateUserContactCommand, UserContactDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserContactCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<UserContactDto> Handle(CreateUserContactCommand request, CancellationToken cancellationToken)
    {
        var userContact = new UserContact
        {
            IdContact = request.UserContact.IdContact,
            IdUser = request.UserContact.IdUser
        };

        var created = _unitOfWork.GetRepository<UserContact>().Create(userContact);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<UserContactDto>(created));
    }
}