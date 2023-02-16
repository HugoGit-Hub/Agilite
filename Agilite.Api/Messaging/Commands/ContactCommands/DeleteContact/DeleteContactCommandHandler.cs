using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.ContactCommands.DeleteContact;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, ContactDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteContactCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<ContactDto> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact
        {
            IdContact = request.Contact.IdContact,
            ArchivedContact = request.Contact.ArchivedContact,
            NameContact = request.Contact.NameContact
        };

        var deleted = _unitOfWork.GetRepository<Contact>().Delete(contact);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<ContactDto>(deleted));
    }
}