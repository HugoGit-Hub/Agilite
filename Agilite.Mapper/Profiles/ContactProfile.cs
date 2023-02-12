using Agilite.DataTransferObject.DTOs;
using Agilite.Entities.Entities;
using AutoMapper;

namespace Agilite.Mapper.Profiles;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<Contact, ContactDto>();
        CreateMap<ContactDto, Contact>()
            .ForMember(entity => entity.UserMessageContacts, member => member.Ignore());
    }
}