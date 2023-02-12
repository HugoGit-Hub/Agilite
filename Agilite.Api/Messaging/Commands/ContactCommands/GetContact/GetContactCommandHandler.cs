using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.ContactCommands.GetContact;

public class GetContactCommandHandler : IRequestHandler<GetContactCommand, ContactDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetContactCommandHandler(IUnitOfWork nunitOfWork, IMapper mapper)
    {
        _unitOfWork = nunitOfWork;
        _mapper = mapper;
    }

    public Task<ContactDto> Handle(GetContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact
        {
            IdContact = request.id
        };

        var get = _unitOfWork.GetRepositoryEntityById<Contact, int>().Get(contact.IdContact);
        return Task.FromResult(_mapper.Map<ContactDto>(get));
    }
}