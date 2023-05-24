using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserContactCommands.GetUserContact;

public class GetUserContactCommandHandler : IRequestHandler<GetUserContactCommand, UserContactDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserContactCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<UserContactDto> Handle(GetUserContactCommand request, CancellationToken cancellationToken)
    {
        var userContact = new UserContact
        {
            IdContact = request.Id
        };

        var get = _unitOfWork.GetRepositoryEntityById<UserContactDto, int>().Get(userContact.IdContact);
        return Task.FromResult(_mapper.Map<UserContactDto>(get));
    }
}