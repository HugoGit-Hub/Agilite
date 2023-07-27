﻿using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserCommands.GetAllTeamsOfOneUser;

public record GetAllTeamsOfOneUserCommand(int IdUser) : IRequest<IEnumerable<TeamDto>>;