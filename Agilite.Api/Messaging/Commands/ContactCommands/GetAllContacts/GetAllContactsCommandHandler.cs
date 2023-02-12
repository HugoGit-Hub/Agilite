using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.ContactCommands.GetAllContacts;

public class GetAllContactCommandHandler : IRequestHandler<GetAllContactsCommand, IEnumerable<ContactDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllContactCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IEnumerable<ContactDto>> Handle(GetAllContactsCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<Contact>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<ContactDto>>(getAll));
    }
}