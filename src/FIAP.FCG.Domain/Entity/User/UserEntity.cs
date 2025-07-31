using FIAP.FCG.Domain.Enums.User;

namespace FIAP.FCG.Domain.Entity
{
    public class UserEntity : EntityBase
    {
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public AccessLevelEnum AccessLevel { get; set; }
    }
}
