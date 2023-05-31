using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserContactCommands.GetAllUserContacts;

public class GetAllUserContactsHandler : IRequestHandler<GetAllUserContactsCommand, IEnumerable<UserContactDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllUserContactsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IEnumerable<UserContactDto>> Handle(GetAllUserContactsCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<UserContact>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<UserContactDto>>(getAll));
    }
}