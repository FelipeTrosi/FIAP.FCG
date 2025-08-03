using FIAP.FCG.Domain.Enums.User;

namespace FIAP.FCG.Service.Dto.User;

public class UserCreateDto
{
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public AccessLevelEnum AccessLevel { get; set; }
}
