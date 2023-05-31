using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserTeamCommands.GetAllUserTeams;

public sealed record GetAllUserTeamsCommand : IRequest<IEnumerable<UserTeamDto>>;