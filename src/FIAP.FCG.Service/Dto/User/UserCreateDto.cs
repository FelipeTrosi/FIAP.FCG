using FIAP.FCG.Domain.Enums.User;

namespace FIAP.FCG.Service.Dto.User;

/// <summary>
/// DTO para criação de um novo usuário.
/// </summary>
public class UserCreateDto
{
    /// <summary>
    /// Endereço de e-mail do usuário.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Nome completo do usuário.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Senha de acesso do usuário. (Mínimo de 8 caracteres com números, letras e caracteres especiais)
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// Nível de acesso do usuário.
    /// </summary>
    public AccessLevelEnum AccessLevel { get; set; }
}
