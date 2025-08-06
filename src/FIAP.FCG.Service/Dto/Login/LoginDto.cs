namespace FIAP.FCG.Service.Dto.Login;

/// <summary>
/// DTO usado para autenticação de usuários no sistema.
/// </summary>
public class LoginDto
{
    /// <summary>
    /// Nome de usuário ou e-mail utilizado no login.
    /// </summary>
    public string Username { get; set; } = null!;

    /// <summary>
    /// Senha de acesso do usuário.
    /// </summary>
    public string Password { get; set; } = null!;
}
