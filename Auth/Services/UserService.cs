using AutoMapper;
using TaskApi.Auth.Data.DTOs;
using TaskApi.Auth.Models;

namespace TaskApi.Auth.Services;

public class UserService
{
    private IMapper _mapper;

    public UserService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public User ConvertUser(CreateUserDto userDto)
    {
        return _mapper.Map<User>(userDto);
    }
}
