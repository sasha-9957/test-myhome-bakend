using Microsoft.AspNetCore.Mvc;
using MyHomeNet.Models;
using MyHomeNet.Service;

namespace MyHomeNet.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new []{"Test", "request"};
    }
}

