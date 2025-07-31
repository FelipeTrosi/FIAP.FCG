using FIAP.FCG.Domain.Enums.User;

namespace FIAP.FCG.Domain.Entity.User.Input
{
    public class UpdateUserInput : EntityBase
    {
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public AccessLevelEnum AccessLevel { get; set; }
    }
}
