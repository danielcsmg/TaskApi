using TaskApi.Auth.Models;

namespace TaskApi.Auth.Data.Daos.InterfacesDao;

public interface IUserDao
{
    public Task CreateUser(User user, string passwd);
}
