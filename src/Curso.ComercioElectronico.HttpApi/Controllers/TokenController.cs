using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Curso.ComercioElectronico.Application;
using Curso.ComercioElectronico.HttpApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
namespace Curso.ComercioElectronico.HttpApi.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly JwtConfiguration jwtConfiguration;
    private readonly IConfiguration iconfiguration;
    private readonly IOptions<AppSetting> ioption;

    public TokenController(JwtConfiguration jwtConfiguration, IConfiguration iconfiguration, IOptions<AppSetting> ioption)
    {
        this.jwtConfiguration = jwtConfiguration;
        this.iconfiguration = iconfiguration;
        this.ioption = ioption;
    }

    [HttpPost]
    public async Task<string> TokenAsync(UserInput input)
    {

        var appSetting = new AppSetting();

        UserInput[] userList = iconfiguration.GetSection("Usuarios").Get<UserInput[]>();

        var usuarios = appSetting.UserInputs;

        if (!usuarios.Any(u => u.UserName.Equals(input.UserName)) || input.Password != "0000")
        {
            throw new AuthenticationException("User or Passowrd incorrect!");
        }

        var claims = new List<Claim>();

        var user = usuarios.Single(u => u.UserName.Equals(input.UserName));

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.UserName));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()));
        claims.Add(new Claim("UserName", input.UserName));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new JwtSecurityToken(
            jwtConfiguration.Issuer,
            jwtConfiguration.Audience,
            claims,
            expires: DateTime.UtcNow.Add(jwtConfiguration.Expires),
            signingCredentials: signIn);


        var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);


        return jwt;
    }
}
