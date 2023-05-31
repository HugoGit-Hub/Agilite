using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveTypeCommands.DeleteObjectiveType;

public class DeleteObjectiveTypeCommandHandler : IRequestHandler<DeleteObjectiveTypeCommand, ObjectiveTypeDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteObjectiveTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<ObjectiveTypeDto> Handle(DeleteObjectiveTypeCommand request, CancellationToken cancellationToken)
    {
        var objectiveType = new ObjectiveType
        {
            IdObjectiveType = request.ObjectiveType.IdObjectiveType,
            NameObjectiveType = request.ObjectiveType.NameObjectiveType
        };

        var deleted = _unitOfWork.GetRepository<ObjectiveType>().Delete(objectiveType);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<ObjectiveTypeDto>(deleted));
    }
}