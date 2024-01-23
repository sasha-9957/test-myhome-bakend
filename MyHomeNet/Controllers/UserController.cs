using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHomeNet.Models;
using MyHomeNet.Service;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyHomeNet.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUsersService _service;
    
    [HttpPost("login")]
    public async Task <IActionResult> Post([FromBody] LoginRequest loginRequest)
    {
        var user = await _service.Get(loginRequest.Email);
        if (user == null)
        {
            return Ok(new Contracts.ApiResponse
            {
                Success = true,
                ErrorCode = "NotFound",
                Message = "User not found",
            });
        }
        
        var claims = new List<Claim> {new Claim(ClaimTypes.Email, loginRequest.Email)};
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(60)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            
        var token =  new JwtSecurityTokenHandler().WriteToken(jwt);
        return Ok(new LoginResponse()
        {
            Success = true,
            User = user,
            Token = token
        });
    }

    public UserController(IUsersService service)
    {
        _service = service;
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _service.GetAll());
    }
    [HttpGet("get")]
    [Authorize]
    public async Task<IActionResult> GetUser(int id)
    {
        return Ok(await _service.Get(id));
    }
    
    [HttpGet("getbyemail")]
    //[Authorize]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        var response = await _service.Get(email);
        
            return Ok(new UserResponse
            {
                Success = true,
                User = response
            });

    }
    [HttpPost("add")]
    public async Task<IActionResult> AddUser(User user)
    {
        return Ok(await _service.AddUser(user));
    }
    
    async Task<IActionResult> Handle<T>(Func<IUsersService, Task<T>> func)
    {
        try
        {
            return Ok(await func(_service));
        }
        catch (ChannelsApiExceptions.ChannelsApiException apiEx)
        {
            //log.Warning(apiEx, "Query resulted in error");
            return Ok(new Contracts.ApiResponse
            {
                Success = false,
                ErrorCode = apiEx.Code,
                Message = apiEx.Message,
            });
        }
        catch (Exception ex)
        {
            return Ok(new Contracts.ApiResponse
            {
                Success = false,
                ErrorCode = ex.GetType().ToString(),
                Message = ex.Message,
            });
        }
    }
    
    public class ListUserResponse : Contracts.ApiResponse
    {
        public List<User> Users;
    }
    
    public class UserResponse : Contracts.ApiResponse
    {
        public User User;
    }
    public class LoginResponse : UserResponse
    {
        public string Token;
    }
}

