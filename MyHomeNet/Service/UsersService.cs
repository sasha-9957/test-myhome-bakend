using MyHomeNet.Models;

namespace MyHomeNet.Service;

public class UsersService : IUsersService
{
    MyHomeContext _context;

    public UsersService(MyHomeContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await Task.FromResult(_context.Users);
    }
    public async Task<User> Get(int id)
    {
        return await Task.FromResult(_context.Users.FirstOrDefault(c => c.Id == id));
    }
    public async Task<User> Get(string email)
    {
        return await Task.FromResult(_context.Users.FirstOrDefault(c => c.Email == email));
    }
    
    public async Task<bool> AddUser(User user)
    {
        try
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            throw;
        }
       
    }
}