using Agilite.DataTransferObject;
using Agilite.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class MessageProfile : Profile
{
    public MessageProfile()
    {
        CreateMap<Message, MessageDto>();
        CreateMap<MessageDto, Message>()
            .ForMember(entity => entity.IdUserNavigation, member => member.Ignore());
    }
}