using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.ContactCommands.UpdateContact;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ContactDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateContactCommandHandler(IUnitOfWork unitOfWork, IMapper iMapper)
    {
        _unitOfWork = unitOfWork;
        this._mapper = iMapper;
    }

    public Task<ContactDto> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact
        {
            IdContact = request.Contact.IdContact,
            NameContact = request.Contact.NameContact,
            ArchivedContact = request.Contact.ArchivedContact
        };

        var created = _unitOfWork.GetRepository<Contact>().Update(contact);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<ContactDto>(created));
    }
}