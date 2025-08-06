using FIAP.FCG.Service.Dto.Login;
using FIAP.FCG.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.FCG.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    /// <summary>
    /// Realiza login do usuário e retorna um token JWT.
    /// </summary>
    /// <param name="input">Credenciais de login.</param>
    /// <returns>Token JWT para autenticação.</returns>
    /// <response code="200">Login realizado com sucesso.</response>
    /// <response code="401">Credenciais inválidas.</response>
    [HttpPost("Login")]
    public IActionResult Login([FromBody] LoginDto input)
    {
        return Ok(new { token = _authService.Login(input) });
    }
}
