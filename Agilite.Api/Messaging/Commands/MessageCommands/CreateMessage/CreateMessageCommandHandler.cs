using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.MessageCommands.CreateMessage;

public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, MessageDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateMessageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<MessageDto> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        var message = new Message
        {
            IdMessage = request.Message.IdMessage,
            TextMessage = request.Message.TextMessage
        };

        var created = _unitOfWork.GetRepository<Message>().Create(message);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<MessageDto>(created));
    }
}