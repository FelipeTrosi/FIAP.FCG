using FIAP.FCG.Domain.Entity.Input;
using FIAP.FCG.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.FCG.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController (IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginInput input)
        {
            if (input.Username == "admin" && input.Password == "admin")
            {
                var token = _authService.GenerateJwtToken(input.Username, "Admin");
                return Ok(new { token });
            }
            else if (input.Username == "user" && input.Password == "user")
            {
                var token = _authService.GenerateJwtToken(input.Username, "User");
                return Ok(new { token });
            }
            else
            {
                return Unauthorized("Login inválido");
            }

        }
    }
}
