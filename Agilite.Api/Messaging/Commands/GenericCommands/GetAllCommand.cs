﻿using MediatR;

namespace Agilite.Api.Messaging.Commands.GenericCommands;

public record GetAllCommand<TEntityDto>(Type EntityType) : IRequest<IEnumerable<TEntityDto>>;