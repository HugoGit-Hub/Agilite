using Agilite.Api.Messaging.Commands.SprintObjectiveCommands.CreateSprintObjective;
using Agilite.Api.Messaging.Commands.SprintObjectiveCommands.DeleteSprintObjective;
using Agilite.Api.Messaging.Commands.SprintObjectiveCommands.GetAllSprintObjectives;
using Agilite.Api.Messaging.Commands.SprintObjectiveCommands.GetSprintObjective;
using Agilite.Api.Messaging.Commands.SprintObjectiveCommands.UpdateSprintObjective;
using Agilite.DataTransferObject.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintObjectiveController : ControllerBase
    {
        private readonly ISender _sender;

        public SprintObjectiveController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost(nameof(CreateSprintObjective))]
        public async Task<SprintObjectiveDto> CreateSprintObjective(SprintObjectiveDto sprintObjective)
            => await _sender.Send(new CreateSprintObjectiveCommand(sprintObjective));

        [HttpPut(nameof(UpdateSprintObjective))]
        public async Task<SprintObjectiveDto> UpdateSprintObjective(SprintObjectiveDto sprintObjective)
            => await _sender.Send(new UpdateSprintObjectiveCommand(sprintObjective));

        [HttpGet(nameof(GetAllSprintObjectives))]
        public async Task<IEnumerable<SprintObjectiveDto>> GetAllSprintObjectives()
            => await _sender.Send(new GetAllSprintObjectivesCommand());

        [HttpGet(nameof(GetSprintObjective))]
        public async Task<SprintObjectiveDto> GetSprintObjective(int id)
            => await _sender.Send(new GetSprintObjectiveCommand(id));

        [HttpDelete(nameof(DeleteSprintObjective))]
        public async Task<SprintObjectiveDto> DeleteSprintObjective(SprintObjectiveDto sprintObjective)
            => await _sender.Send(new DeleteSprintObjectiveCommand(sprintObjective));
    }
}
