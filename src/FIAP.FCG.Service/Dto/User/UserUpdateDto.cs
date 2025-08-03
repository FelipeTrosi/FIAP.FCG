using FIAP.FCG.Domain.Enums.User;

namespace FIAP.FCG.Service.Dto.User;

public class UserUpdateDto
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public AccessLevelEnum AccessLevel { get; set; }
}
