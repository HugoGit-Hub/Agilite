﻿using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.UserMessageContactCommands.DeleteUserMessageContact;

public class DeleteUserMessageContactCommandHandler : IRequestHandler<DeleteUserMessageContactCommand, UserMessageContactDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteUserMessageContactCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<UserMessageContactDto> Handle(DeleteUserMessageContactCommand request, CancellationToken cancellationToken)
    {
        var userMessageContact = new UserMessageContact
        {
            UserIdUser = request.UserMessageContact.UserIdUser,
            ContactIdContact = request.UserMessageContact.ContactIdContact,
            MessageIdMessage = request.UserMessageContact.MessageIdMessage,
            DateTimeUserMessageContact = request.UserMessageContact.DateTimeUserMessageContact
        };

        var created = _unitOfWork.GetRepository<UserMessageContact>().Update(userMessageContact);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<UserMessageContactDto>(created));
    }
}
