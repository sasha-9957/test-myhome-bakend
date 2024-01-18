using MyHomeNet.Models;

namespace MyHomeNet.Service;

public class UsersService : IUsersService
{
    MyHomeContext _context;

    public UsersService(MyHomeContext context)
    {
        _context = context;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }
}