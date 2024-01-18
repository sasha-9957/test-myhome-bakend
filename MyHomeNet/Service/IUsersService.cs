using MyHomeNet.Models;

namespace MyHomeNet.Service;

public interface IUsersService
{
    public IEnumerable<User> GetAll();
}