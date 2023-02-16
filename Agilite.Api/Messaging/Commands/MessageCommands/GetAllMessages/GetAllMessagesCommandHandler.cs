using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.MessageCommands.GetAllMessages;

public class GetAllMessagesCommandHandler : IRequestHandler<GetAllMessagesCommand, IEnumerable<MessageDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllMessagesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<MessageDto>> Handle(GetAllMessagesCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<Message>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<MessageDto>>(getAll));
    }
}
