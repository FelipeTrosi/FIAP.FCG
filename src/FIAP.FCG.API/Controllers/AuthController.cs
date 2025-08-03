using FIAP.FCG.Service.Dto.Login;
using FIAP.FCG.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.FCG.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("Login")]
    public IActionResult Login([FromBody] LoginDto input)
    {
        return Ok(new { token = _authService.Login(input) });
    }
}
