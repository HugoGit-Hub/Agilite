using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveTypeCommands.UpdateObjectiveType;

public class UpdateObjectiveTypeCommandHandler : IRequestHandler<UpdateObjectiveTypeCommand, ObjectiveTypeDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateObjectiveTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<ObjectiveTypeDto> Handle(UpdateObjectiveTypeCommand request, CancellationToken cancellationToken)
    {
        var objectiveType = new ObjectiveType
        {
            IdObjectiveType = request.ObjectiveType.IdObjectiveType,
            NameObjectiveType = request.ObjectiveType.NameObjectiveType
        };

        var updated = _unitOfWork.GetRepository<ObjectiveType>().Update(objectiveType);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<ObjectiveTypeDto>(updated));
    }
}