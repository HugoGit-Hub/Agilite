using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveTypeCommands.GetAllObjectiveTypes;

public class GetAllObjectiveTypesCommandHandler : IRequestHandler<GetAllObjectiveTypesCommand, IEnumerable<ObjectiveTypeDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllObjectiveTypesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IEnumerable<ObjectiveTypeDto>> Handle(GetAllObjectiveTypesCommand request, CancellationToken cancellationToken)
    {
        var getAll = _unitOfWork.GetRepository<ObjectiveType>().GetAll();
        return Task.FromResult(_mapper.Map<IEnumerable<ObjectiveTypeDto>>(getAll));
    }
}