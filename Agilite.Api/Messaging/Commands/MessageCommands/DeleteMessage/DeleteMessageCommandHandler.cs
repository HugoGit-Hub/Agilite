using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.MessageCommands.DeleteMessage;

public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, MessageDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteMessageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<MessageDto> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
    {
        var message = new Message
        {
            IdMessage = request.message.IdMessage,
            TextMessage = request.message.TextMessage
        };

        var deleted = _unitOfWork.GetRepository<Message>().Delete(message);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<MessageDto>(deleted));
    }
}
