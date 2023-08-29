using AutoMapper;
using TaskApi.Auth.Data.DTOs;
using TaskApi.Auth.Models;

namespace TaskApi.Auth.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}
