using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.UserMessageContactCommands.CreateUserMessageContact;

public class CreateUserMessageContactCommandHandler : IRequestHandler<CreateUserMessageContactCommand, UserMessageContactDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserMessageContactCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<UserMessageContactDto> Handle(CreateUserMessageContactCommand request, CancellationToken cancellationToken)
    {
        var userMessageContact = new UserMessageContact
        {
            UserIdUser = request.UserMessageContact.UserIdUser,
            ContactIdContact = request.UserMessageContact.ContactIdContact,
            MessageIdMessage = request.UserMessageContact.MessageIdMessage,
            DateTimeUserMessageContact = request.UserMessageContact.DateTimeUserMessageContact
        };

        var created = _unitOfWork.GetRepository<UserMessageContact>().Create(userMessageContact);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<UserMessageContactDto>(created));
    }
}
