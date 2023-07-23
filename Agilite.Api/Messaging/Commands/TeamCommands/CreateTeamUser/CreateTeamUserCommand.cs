using Agilite.DataTransferObject.DTOs;
using MediatR;

namespace Agilite.Api.Messaging.Commands.TeamCommands.CreateTeamUser;

public record CreateTeamUserCommand(int IdTeam, int IdUser) : IRequest<TeamDto>;