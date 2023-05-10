using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using AutoMapper;

namespace Agilite.UI.Mapper.Profiles;

public class UserMessageContactProfile : Profile
{
    public UserMessageContactProfile()
    {
        CreateMap<UserMessageContactDto, UserMessageContactModel>();
        CreateMap<UserMessageContactModel, UserMessageContactDto>();
    }
}