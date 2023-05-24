using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.UserTeamCommands.GetUserTeam;

public sealed record GetUserTeamCommand(int Id) : IRequest<UserTeamDto>;