using Microsoft.AspNetCore.Identity;
using TaskApi.Auth.Data.Daos.InterfacesDao;
using TaskApi.Auth.Models;

namespace TaskApi.Auth.Data.Daos;

public class UserDao : IUserDao
{
    private UserManager<User> _userManager;

    public UserDao(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task CreateUser(User user, string passwd)
    {
        var result = await _userManager.CreateAsync(user, passwd);

        if (!result.Succeeded)
        {
            throw new Exception("Usuário não pode ser cadastrado");
        }
    }
}
