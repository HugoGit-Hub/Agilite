using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.UserMessageContactCommands.GetAllUserMessageContacts;

public class GetAllUserMessageContactsCommandHandler : IRequestHandler<GetAllUserMessageContactsCommand, IEnumerable<UserMessageContactDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllUserMessageContactsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IEnumerable<UserMessageContactDto>> Handle(GetAllUserMessageContactsCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<UserMessageContact>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<UserMessageContactDto>>(getAll));
    }
}