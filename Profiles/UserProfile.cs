using AutoMapper;
using sign_up_api.Entities;
using sign_up_api.Models;

namespace sign_up_api.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserForCreationDto, User>();
    }
}
