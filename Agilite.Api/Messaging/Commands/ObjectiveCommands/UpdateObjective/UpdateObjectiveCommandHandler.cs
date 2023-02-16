﻿using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Agilite.Api.Messaging.Commands.ObjectiveCommands.UpdateObjective;

public class UpdateObjectiveCommandHandler : IRequestHandler<UpdateObjectiveCommand, ObjectiveDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateObjectiveCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Task<ObjectiveDto> Handle(UpdateObjectiveCommand request, CancellationToken cancellationToken)
    {
        var objective = new Objective
        {
            IdObjective = request.Objective.IdObjective,
            SprintIdSprint = request.Objective.SprintIdSprint,
            NameObjective = request.Objective.NameObjective,
            NumberObjective = request.Objective.NumberObjective,
            EnumTypeObjective = request.Objective.EnumTypeObjective,
            TextObjective = request.Objective.TextObjective,
        };

        var updated = _unitOfWork.GetRepository<Objective>().Update(objective);
        _unitOfWork.Save();
        return Task.FromResult(_mapper.Map<ObjectiveDto>(updated));
    }
}