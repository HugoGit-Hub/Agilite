using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using AutoMapper;

namespace Agilite.UI.Mapper.Profiles;

public class LoginProfile : Profile
{
    public LoginProfile()
    {
        CreateMap<LoginDto, LoginModel>();
        CreateMap<LoginModel, LoginDto>();
    }
}