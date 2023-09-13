using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.MessageCommands.GetMessage;

public class GetMessageCommandHandler : IRequestHandler<GetMessageCommand, MessageDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetMessageCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Task<MessageDto> Handle(GetMessageCommand request, CancellationToken cancellationToken)
    {
        var contact = new Message
        {
            IdMessage = request.id
        };

        var get = _unitOfWork.GetRepositoryEntityById<Message, int>().Get(contact.IdMessage);
        return Task.FromResult(_mapper.Map<MessageDto>(get));
    }
}