using Agilite.DataTransferObject;
using Agilite.UI.Models.Models;
using AutoMapper;

namespace Agilite.UI.Mapper.Profiles;

public class MessageProfile : Profile
{
    public MessageProfile()
    {
        CreateMap<MessageDto, MessageModel>();
        CreateMap<MessageModel, MessageDto>();
    }
}