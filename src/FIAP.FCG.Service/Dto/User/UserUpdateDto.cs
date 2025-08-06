using FIAP.FCG.Domain.Enums.User;

namespace FIAP.FCG.Service.Dto.User;

/// <summary>
/// DTO para atualização dos dados de um usuário existente.
/// </summary>
public class UserUpdateDto
{
    /// <summary>
    /// Identificador único do usuário a ser atualizado.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Data original de criação do usuário.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Novo endereço de e-mail do usuário.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Novo nome completo do usuário.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Nova senha do usuário.
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// Nível de acesso do usuário. Valores possíveis: USER (0), ADMIN (1).
    /// </summary>
    public AccessLevelEnum AccessLevel { get; set; }
}

