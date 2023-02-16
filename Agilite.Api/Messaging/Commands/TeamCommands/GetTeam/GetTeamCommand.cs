using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamCommands.GetTeam;

public sealed record GetTeamCommand(int id) : IRequest<TeamDto>;