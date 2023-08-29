using Microsoft.AspNetCore.Mvc;
using TaskApi.Auth.Data.Daos.InterfacesDao;
using TaskApi.Auth.Data.DTOs;
using TaskApi.Auth.Models;
using TaskApi.Auth.Services;

namespace TaskApi.Auth;

[ApiController]
[Route("[Controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;
    private readonly IUserDao _userDao;

    public UsersController(UserService userService, IUserDao userDao)
    {
        _userService = userService;
        _userDao = userDao;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(CreateUserDto userDto)
    {
        User user = _userService.ConvertUser(userDto);

        await _userDao.CreateUser(user, userDto.Password);

        return Ok("Usuário cadastrado com sucesso!");
    }

    [HttpGet]
    public IActionResult GetUser()
    {
        return Ok("Usuário cadastrado com sucesso!");
    }
}
