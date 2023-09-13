using Agilite.DataTransferObject;
using Agilite.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveTypeCommands.CreateObjectiveType;

public class CreateObjectiveTypeCommandHandler : IRequestHandler<CreateObjectiveTypeCommand, ObjectiveTypeDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateObjectiveTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<ObjectiveTypeDto> Handle(CreateObjectiveTypeCommand request, CancellationToken cancellationToken)
    {
        var objectiveType = new ObjectiveType
        {
            IdObjectiveType = request.ObjectiveType.IdObjectiveType,
            NameObjectiveType = request.ObjectiveType.NameObjectiveType
        };

        var created = _unitOfWork.GetRepository<ObjectiveType>().Create(objectiveType);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<ObjectiveTypeDto>(created));
    }
}