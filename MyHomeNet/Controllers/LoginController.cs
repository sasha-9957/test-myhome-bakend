using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MyHomeNet.Models;

namespace MyHomeNet.Controllers;

[Route("[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] LoginRequest loginRequest)
    {
        var claims = new List<Claim> {new Claim(ClaimTypes.Email, loginRequest.Email)};
        var jwt = new JwtSecurityToken(
          issuer: AuthOptions.ISSUER,
          audience: AuthOptions.AUDIENCE,
          claims: claims,
          expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
          signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            
      var token =  new JwtSecurityTokenHandler().WriteToken(jwt);

        return Ok(token);
    }
}

