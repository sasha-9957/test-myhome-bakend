
using Microsoft.EntityFrameworkCore;

namespace MyHomeNet.Models;

public class MyHomeContext : DbContext
{
    public MyHomeContext(DbContextOptions<MyHomeContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<User> Users { get; set; } = null!;
}