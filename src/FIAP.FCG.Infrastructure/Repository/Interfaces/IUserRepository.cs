using FIAP.FCG.Domain.Entity;

namespace FIAP.FCG.Infrastructure.Repository.Interfaces;

public interface IUserRepository : IRepository<UserEntity>
{
    UserEntity? GetByUserAndPassword(string user, string password);
}
