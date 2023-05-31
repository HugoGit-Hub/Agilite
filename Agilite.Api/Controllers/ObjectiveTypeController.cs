using Agilite.Api.Messaging.Commands.ObjectiveTypeCommands.CreateObjectiveType;
using Agilite.Api.Messaging.Commands.ObjectiveTypeCommands.DeleteObjectiveType;
using Agilite.Api.Messaging.Commands.ObjectiveTypeCommands.GetAllObjectiveTypes;
using Agilite.Api.Messaging.Commands.ObjectiveTypeCommands.GetObjectiveType;
using Agilite.Api.Messaging.Commands.ObjectiveTypeCommands.UpdateObjectiveType;
using Agilite.DataTransferObject.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agilite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectiveTypeController : ControllerBase
    {
        private readonly ISender _sender;

        public ObjectiveTypeController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost(nameof(CreateObjectiveType))]
        public async Task<ObjectiveTypeDto> CreateObjectiveType(ObjectiveTypeDto objectiveType)
            => await _sender.Send(new CreateObjectiveTypeCommand(objectiveType));

        [HttpPut(nameof(UpdateObjectiveType))]
        public async Task<ObjectiveTypeDto> UpdateObjectiveType(ObjectiveTypeDto objectiveType)
            => await _sender.Send(new UpdateObjectiveTypeCommand(objectiveType));

        [HttpGet(nameof(GetAllObjectiveTypes))]
        public async Task<IEnumerable<ObjectiveTypeDto>> GetAllObjectiveTypes()
            => await _sender.Send(new GetAllObjectiveTypesCommand());

        [HttpGet(nameof(GetObjectiveType))]
        public async Task<ObjectiveTypeDto> GetObjectiveType(int id)
            => await _sender.Send(new GetObjectiveTypeCommand(id));

        [HttpDelete(nameof(DeleteObjectiveType))]
        public async Task<ObjectiveTypeDto> DeleteObjectiveType(ObjectiveTypeDto objectiveType)
            => await _sender.Send(new DeleteObjectiveTypeCommand(objectiveType));
    }
}
