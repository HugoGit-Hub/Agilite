﻿using Agilite.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Agilite.Api.Messaging.Commands.GenericCommands;

public abstract class GetAllCommandHandler<TEntityDto, TCommand> : IRequestHandler<TCommand, IEnumerable<TEntityDto>>
    where TCommand : GetAllCommand<TEntityDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    protected GetAllCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<TEntityDto>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var repositoryInstance =
            _unitOfWork
                .GetType()
                .GetMethod(nameof(IUnitOfWork.GetRepository))!
                .MakeGenericMethod(request.EntityType)
                .Invoke(_unitOfWork, null);

        var getAllMethod = repositoryInstance!.GetType().GetMethod(nameof(IRepository<object>.GetAll));
        var result = getAllMethod!.Invoke(repositoryInstance, null);
        return Task.FromResult(_mapper.Map<IEnumerable<TEntityDto>>(result));
    }
}