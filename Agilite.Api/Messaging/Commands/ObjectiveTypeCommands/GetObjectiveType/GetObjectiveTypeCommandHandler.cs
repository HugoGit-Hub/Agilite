using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveTypeCommands.GetObjectiveType;

public class GetObjectiveTypeCommandHandler : IRequestHandler<GetObjectiveTypeCommand, ObjectiveTypeDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetObjectiveTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<ObjectiveTypeDto> Handle(GetObjectiveTypeCommand request, CancellationToken cancellationToken)
    {
        var objectiveType = new ObjectiveType
        {
            IdObjectiveType = request.Id
        };

        var get = _unitOfWork.GetRepositoryEntityById<ObjectiveType, int>().Get(objectiveType.IdObjectiveType);
        return Task.FromResult(_mapper.Map<ObjectiveTypeDto>(get));
    }
}