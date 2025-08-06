using FIAP.FCG.Domain.Enums.User;

namespace FIAP.FCG.Service.Dto.User;

/// <summary>
/// Representa os dados de saída de um usuário cadastrado.
/// </summary>
public class UserOutputDto
{
    /// <summary>
    /// Identificador único do usuário.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Data e hora de criação do usuário.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Endereço de e-mail do usuário.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Nome completo do usuário.
    /// </summary>
    public string Name { get; set; } = null!;

    public AccessLevelEnum AccessLevel { get; set; }
}
