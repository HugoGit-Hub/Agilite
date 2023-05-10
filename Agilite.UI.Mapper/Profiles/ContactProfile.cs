using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using AutoMapper;

namespace Agilite.UI.Mapper.Profiles;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<ContactDto, ContactModel>();
        CreateMap<ContactModel, ContactDto>();
    }
}