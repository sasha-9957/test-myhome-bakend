using MyHomeNet.Models;

namespace MyHomeNet.Service;

public interface IUsersService
{
    public Task<IEnumerable<User>> GetAll();
    public Task<User?> Get(int id);
    public Task<User?> Get(string email);
    public Task<bool> AddUser(User user);
}