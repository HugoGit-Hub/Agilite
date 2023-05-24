﻿using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.ObjectiveTypeCommands.CreateObjectiveType;

public sealed record CreateObjectiveTypeCommand(ObjectiveTypeDto ObjectiveType) : IRequest<ObjectiveTypeDto>;