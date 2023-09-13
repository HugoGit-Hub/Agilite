using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.MessageCommands.UpdateMessage;

public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand, MessageDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMessageCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Task<MessageDto> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
    {
        var message = new Message
        {
            IdMessage = request.Message.IdMessage,
            TextMessage = request.Message.TextMessage
        };

        var created = _unitOfWork.GetRepository<Message>().Update(message);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<MessageDto>(created));
    }
}