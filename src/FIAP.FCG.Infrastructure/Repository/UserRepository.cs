using FIAP.FCG.Domain.Repository.Interfaces;
using FIAP.FCG.Domain.Entity;

namespace FIAP.FCG.Infrastructure.Repository
{
    public class UserRepository : EFRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
