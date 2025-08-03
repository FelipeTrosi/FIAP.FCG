using FIAP.FCG.Domain.Entity;
using FIAP.FCG.Infrastructure.Repository.Interfaces;

namespace FIAP.FCG.Infrastructure.Repository
{
    public class UserRepository : EFRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public UserEntity? GetByUserAndPassword(string user, string password)
            => _context.User.FirstOrDefault(q => q.Name == user && q.Password == password);

    }
}
