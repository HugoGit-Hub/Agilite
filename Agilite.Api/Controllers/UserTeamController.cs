using Agilite.Api.Messaging.Commands.UserTeamCommands.CreateUserTeam;
using Agilite.Api.Messaging.Commands.UserTeamCommands.DeleteUserTeam;
using Agilite.Api.Messaging.Commands.UserTeamCommands.GetAllUserTeams;
using Agilite.Api.Messaging.Commands.UserTeamCommands.GetUserTeam;
using Agilite.Api.Messaging.Commands.UserTeamCommands.GetUserTeamByUserId;
using Agilite.Api.Messaging.Commands.UserTeamCommands.UpdateUserTeam;
using Agilite.DataTransferObject.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTeamController : ControllerBase
    {
        private readonly ISender _sender;

        public UserTeamController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost(nameof(CreateUserTeam))]
        public async Task<UserTeamDto> CreateUserTeam(UserTeamDto userTeam)
            => await _sender.Send(new CreateUserTeamCommand(userTeam));

        [HttpPut(nameof(UpdateUserTeam))]
        public async Task<UserTeamDto> UpdateUserTeam(UserTeamDto userTeam)
            => await _sender.Send(new UpdateUserTeamCommand(userTeam));

        [HttpGet(nameof(GetAllUserTeams))]
        public async Task<IEnumerable<UserTeamDto>> GetAllUserTeams()
            => await _sender.Send(new GetAllUserTeamsCommand());

        [HttpGet(nameof(GetUserTeamByUserId))]
        public async Task<IEnumerable<UserTeamDto>> GetUserTeamByUserId(int id)
            => await _sender.Send(new GetUserTeamByUserIdCommand(id));

        [HttpGet(nameof(GetUserTeam))]
        public async Task<UserTeamDto> GetUserTeam(int id)
            => await _sender.Send(new GetUserTeamCommand(id));

        [HttpDelete(nameof(DeleteUserTeam))]
        public async Task<UserTeamDto> DeleteUserTeam(UserTeamDto userTeam)
            => await _sender.Send(new DeleteUserTeamCommand(userTeam));
    }
}
