using FIAP.FCG.Domain.Enums.User;
using FIAP.FCG.Service.Dto.Login;
using FIAP.FCG.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FIAP.FCG.API.Services;

public class AuthService(IConfiguration configuration, IUserService service) : IAuthService
{
    private readonly IUserService _service = service;
    private readonly IConfiguration _configuration = configuration;

    public string Login(LoginDto input)
    {
        var result = _service.GetByUserAndPassword(input.Username, input.Password);

        switch (result.AccessLevel)
        {
            case AccessLevelEnum.USER:
                return GenerateJwtToken(input.Username, "User");
            case AccessLevelEnum.ADMIN:
                return GenerateJwtToken(input.Username, "Admin");
            default:
                return GenerateJwtToken(input.Username, "User");
        }

    }

    private string GenerateJwtToken(string userId, string role)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)), SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
