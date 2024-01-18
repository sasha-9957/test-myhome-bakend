using Microsoft.AspNetCore.Mvc;
using MyHomeNet.Models;
using MyHomeNet.Service;

namespace MyHomeNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUsersService _service;

    public UserController(IUsersService service)
    {
        _service = service;
    }
    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
        return _service.GetAll();
    }
}

